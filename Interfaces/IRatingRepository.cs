using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Models;

namespace movies_api.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetManyAsync();
        Task<Rating?> GetByIdAsync(int id);
        Task<Rating> CreateAsync(Rating model);
        Task<Rating?> UpdateAsync(int id, Rating model);
        Task<Rating?> DeleteAsync(int id, Rating model);
    }
}