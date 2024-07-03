using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movies_api.Database;
using movies_api.models;

namespace movies_api.Repositories
{
    public class GenreRepository
    {
        private readonly ApplicationDBContext _context;
        public GenreRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateAsync(Genre model)
        {
            await _context.Genres.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
            {
                return null;
            }
            return genre;
        }

        public async Task<bool> MovieExistes(int id)
        {
            var movieExistes = await _context.Movies.AnyAsync(m => m.Id == id);
            return movieExistes;
        }
    }
}