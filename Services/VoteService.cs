using Microsoft.EntityFrameworkCore;
using social.Data;
using social.Dtos;
using social.Helpers;
using social.Interfaces;
using social.Models;

namespace social.Services
{
    public class VoteService(ApplicationDBContext dbContext) : IBaseService<Answer>
    {
        private readonly ApplicationDBContext _dbContext = dbContext;

        public async Task<Answer?> CreateAsync(Answer answer)
        {
            await _dbContext.Answers.AddAsync(answer);
            await _dbContext.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer?> DeleteAsync(int id)
        {
            var answer = await _dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
            if (answer != null)
            {
                _dbContext.Answers.Remove(answer);
                await _dbContext.SaveChangesAsync();
            }

            return answer;
        }

        public Task<List<Answer>> GetAllAsync(IBaseQueryObject? query)
        {
            throw new NotImplementedException();
        }

        public Task<Answer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Answer?> UpdateAsync(int id, IBaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
