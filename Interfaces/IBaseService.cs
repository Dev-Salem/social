using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using social.Dtos;
using social.Helpers;

namespace social.Interfaces
{
    public interface IBaseService<T>
    {
        public Task<List<T>> GetAllAsync(IBaseQueryObject? query);
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> CreateAsync(T t);
        public Task<T?> UpdateAsync(int id, IBaseDTO dto);
        public Task<T?> DeleteAsync(int id);
    }
}
