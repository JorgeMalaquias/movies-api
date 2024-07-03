using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IMovieRepository
    {

        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie model);
        Task<bool> MovieExistes(int id);
    }
}