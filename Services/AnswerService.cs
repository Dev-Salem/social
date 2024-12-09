using Microsoft.EntityFrameworkCore;
using social.Data;
using social.Dtos;
using social.Helpers;
using social.Interfaces;
using social.Models;

namespace social.Services
{
    public class AnswerService(ApplicationDBContext context) : IBaseService<Answer>
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Answer?> CreateAsync(Answer answer)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == answer.PostId);
            if (post == null)
                return null;
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer?> DeleteAsync(int id)
        {
            var answer = await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
            if (answer == null)
                return null;
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<List<Answer>> GetAllAsync(IBaseQueryObject? query) =>
            await _context.Answers.ToListAsync();

        public async Task<Answer?> GetByIdAsync(int id) =>
            await _context.Answers.Include(x => x.Post).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Answer?> UpdateAsync(int id, IBaseDTO dto)
        {
            var answer = await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
            if (answer == null)
                return null;
            answer.Content = ((AnswerDTO)dto).Content;
            await _context.SaveChangesAsync();
            return answer;
        }
    }
}
