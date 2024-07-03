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
        public async Task<Rating> CreateAsync(Rating model)
        {
            await _context.Ratings.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
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
    }
}