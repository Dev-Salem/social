using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using social.Data;
using social.Dtos;
using social.Helpers;
using social.Interfaces;
using social.Models;

namespace social.Services
{
    public class PostService(ApplicationDBContext context) : IBaseService<Post>
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Post>> GetAllAsync(IBaseQueryObject? query)
        {
            var posts = _context.Posts.AsQueryable();
            if (query != null)
            {
                posts = GetQueryPosts(posts, (query as PostQueryObject)!);
            }

            return await posts.ToListAsync();
        }

        private IQueryable<Post> GetQueryPosts(IQueryable<Post> posts, PostQueryObject query)
        {
            if (!string.IsNullOrWhiteSpace(query?.Content))
                posts = posts.Where(x => x.Content.ToLower().Contains(query.Content.ToLower()));
            if (!string.IsNullOrWhiteSpace(query?.Title))
                posts = posts.Where(x => x.Title.ToLower().Contains(query.Title.ToLower()));

            if (!string.IsNullOrWhiteSpace(query?.SortBy))
            {
                if (query.SortBy.Equals("date", StringComparison.OrdinalIgnoreCase))
                {
                    posts = query.IsDescending
                        ? posts.OrderByDescending(x => x.CreatedAt)
                        : posts.OrderBy(x => x.CreatedAt);
                }
                if (query.SortBy.Equals("votes", StringComparison.OrdinalIgnoreCase))
                {
                    posts = query.IsDescending
                        ? posts.OrderByDescending(x => x.Votes)
                        : posts.OrderBy(x => x.Votes);
                }
                if (query.SortBy.Equals("views", StringComparison.OrdinalIgnoreCase))
                {
                    posts = query.IsDescending
                        ? posts.OrderByDescending(x => x.Views)
                        : posts.OrderBy(x => x.Views);
                }
            }
            int skipNumber = (query!.PageNumber - 1) * query.PageSize;
            return posts.Skip(skipNumber).Take(query!.PageSize);
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var post = await _context
                .Posts.Include(x => x.Answers)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task<Post?> CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeleteAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return null;
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> UpdateAsync(int id, IBaseDTO body)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return null;
            post.Title = ((PostRequestBody)body).Title;
            post.Content = ((PostRequestBody)body).Content;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> CreatePostWithTagsAsync(PostRequestBody postDTO)
        {
            var post = new Post() { Title = postDTO.Title, Content = postDTO.Content };
            foreach (var tagId in postDTO.TagIds)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagId);
                tag?.Posts.Add(post);
            }
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
