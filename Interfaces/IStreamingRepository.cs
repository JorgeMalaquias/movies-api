using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IStreamingRepository
    {
        Task<List<Streaming>> GetManyAsync();
        Task<Streaming?> GetByIdAsync(int id);
        Task<Streaming> CreateAsync(Streaming model);
        Task<Streaming?> UpdateAsync(int id, Streaming model);
        Task<Streaming?> DeleteAsync(int id);
        Task<bool> StreamingExists(string name);
    }
}