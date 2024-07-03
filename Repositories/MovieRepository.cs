using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movies_api.Database;
using movies_api.Interfaces;
using movies_api.models;

namespace movies_api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _context;
        public MovieRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Movie> CreateAsync(Movie model)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return movie;
        }
    }
}