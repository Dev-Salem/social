using Microsoft.EntityFrameworkCore;
using social.Data;
using social.Dtos;
using social.Helpers;
using social.Interfaces;
using social.Models;

namespace social.Services
{
    public class TagService(ApplicationDBContext context) : IBaseService<Tag>
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Tag?> CreateAsync(Tag tag)
        {
            var uniqueTag = await _context.Tags.FirstOrDefaultAsync(x =>
                x.Name.ToLower() == tag.Name.ToLower()
            );
            if (uniqueTag != null)
            {
                return uniqueTag;
            }
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null)
                return null;
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<List<Tag>> GetAllAsync(IBaseQueryObject? query) =>
            await _context.Tags.ToListAsync();

        public async Task<Tag?> GetByIdAsync(int id) =>
            await _context.Tags.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Tag?> UpdateAsync(int id, IBaseDTO dto)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            if (tag == null)
                return null;
            tag.Name = ((TagCreateUpdateDTO)dto).Name;
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
