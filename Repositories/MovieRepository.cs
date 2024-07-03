using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using movies_api.Database;
using movies_api.Helpers;
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

        public async Task<Movie?> ConnectGenreAsync(int movieId, Genre genre)
        {
            var movie = await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return null;
            }
            movie.Genres.Add(genre);

            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> ConnectStreamingAsync(int movieId, Streaming streaming)
        {
            var movie = await _context.Movies.Include(m => m.Streamings).FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return null;
            }
            movie.Streamings.Add(streaming);

            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> CreateAsync(Movie model)
        {
            await _context.Movies.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        public async Task<List<Movie>> GetManyAsync(MovieQuery query)
        {
            var movies = _context.Movies.Include(m => m.Ratings.Average(r => r.RatingNumber)).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                movies = movies.Where(m => m.Title == query.Title || m.Title.Contains(query.Title));
            }
            if (query.MonthNumber != 0)
            {
                movies = movies.Where(m => m.ReleasingDate.Month == query.MonthNumber);
            }
            if (query.Year != 0)
            {
                movies = movies.Where(m => m.ReleasingDate.Year == query.Year);
            }
            if (query.SortByRating)
            {
                movies = movies.OrderBy(m => m.Ratings.Average(r => r.RatingNumber));
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await movies.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<bool> MovieExists(int id)
        {
            var movieExistes = await _context.Movies.AnyAsync(m => m.Id == id);
            return movieExistes;
        }

        public async Task<Movie?> UpdateAsync(int id, Movie model)
        {
            var existingMovie = await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            if (existingMovie == null)
            {
                return null;
            }
            existingMovie.Title = model.Title;
            existingMovie.ReleasingDate = model.ReleasingDate;

            await _context.SaveChangesAsync();
            return existingMovie;
        }
    }
}