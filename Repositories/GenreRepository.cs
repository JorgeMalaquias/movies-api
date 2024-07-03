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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDBContext _context;
        public GenreRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetManyAsync()
        {
            var genres = await _context.Genres.ToListAsync();

            return genres;
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
        public async Task<Genre> CreateAsync(Genre model)
        {
            await _context.Genres.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> GenreExists(int id)
        {
            var movieExistes = await _context.Genres.AnyAsync(g => g.Id == id);
            return movieExistes;
        }

        public async Task<Genre?> UpdateAsync(int id, Genre model)
        {
            var existingGenre = await _context.Genres.FirstOrDefaultAsync(m => m.Id == id);
            if (existingGenre == null)
            {
                return null;
            }
            existingGenre.Name = model.Name;

            await _context.SaveChangesAsync();
            return existingGenre;
        }

        public async Task<Genre?> DeleteAsync(int id)
        {
            var existingGenre = await _context.Genres.FirstOrDefaultAsync(m => m.Id == id);
            if (existingGenre == null)
            {
                return null;
            }
            _context.Genres.Remove(existingGenre);

            await _context.SaveChangesAsync();
            return existingGenre;
        }
    }
}