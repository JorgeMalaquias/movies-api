using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movies_api.Database;
using movies_api.Interfaces;
using movies_api.Models;

namespace movies_api.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDBContext _context;
        public RatingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Rating>> GetManyAsync()
        {
            var ratings = await _context.Ratings.ToListAsync();
            return ratings;
        }
        public async Task<Rating?> GetByIdAsync(int id)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            if (rating == null)
            {
                return null;
            }
            return rating;
        }

        public async Task<Rating> CreateAsync(Rating model)
        {
            await _context.Ratings.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Rating?> DeleteAsync(int id, Rating model)
        {
            var existingRating = await _context.Ratings.FirstOrDefaultAsync(m => m.Id == id);
            if (existingRating == null)
            {
                return null;
            }
            _context.Ratings.Remove(existingRating);

            await _context.SaveChangesAsync();
            return existingRating;
        }

        public async Task<Rating?> UpdateAsync(int id, Rating model)
        {
            var existingRating = await _context.Ratings.FirstOrDefaultAsync(m => m.Id == id);
            if (existingRating == null)
            {
                return null;
            }
            existingRating.RatingNumber = model.RatingNumber;

            await _context.SaveChangesAsync();
            return existingRating;
        }
    }
}