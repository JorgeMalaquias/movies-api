using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetManyAsync();
        Task<Genre?> GetByIdAsync(int id);
        Task<Genre> CreateAsync(Genre model);
        Task<Genre?> UpdateAsync(int id, Genre model);
        Task<Genre?> DeleteAsync(int id);
        Task<bool> GenreExists(int id);
    }
}