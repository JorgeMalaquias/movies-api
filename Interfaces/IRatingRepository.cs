using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Models;

namespace movies_api.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> CreateAsync(Rating model);
        Task<Rating?> GetByIdAsync(int id);
    }
}