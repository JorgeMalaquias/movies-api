using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Helpers;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IMovieRepository
    {

        Task<Movie?> GetByIdAsync(int id);
        Task<List<Movie>> GetManyAsync(MovieQuery query);
        Task<Movie> CreateAsync(Movie model);
        Task<Movie?> UpdateAsync(int id, Movie model);
        Task<Movie?> DeleteAsync(int id);
        Task<Movie?> ConnectGenreAsync(int movieId, Genre genre);
        Task<Movie?> ConnectStreamingAsync(int movieId, Streaming streaming);
        Task<bool> MovieExists(string title);
        Task<bool> MovieExistsId(int id);
    }
}