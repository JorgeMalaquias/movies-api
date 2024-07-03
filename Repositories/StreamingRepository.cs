using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using movies_api.Database;
using movies_api.Interfaces;
using movies_api.models;

namespace movies_api.Repositories
{
    public class StreamingRepository : IStreamingRepository
    {
        private readonly ApplicationDBContext _context;
        public StreamingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Streaming?> GetByIdAsync(int id)
        {
            var streaming = await _context.Streamings.FirstOrDefaultAsync(s => s.Id == id);
            if (streaming == null)
            {
                return null;
            }
            return streaming;
        }

        public async Task<List<Streaming>> GetManyAsync()
        {
            var streamings = await _context.Streamings.ToListAsync();

            return streamings;
        }
        public async Task<Streaming> CreateAsync(Streaming model)
        {
            await _context.Streamings.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Streaming?> DeleteAsync(int id)
        {
            var existingStreaming = await _context.Streamings.FirstOrDefaultAsync(m => m.Id == id);
            if (existingStreaming == null)
            {
                return null;
            }
            _context.Streamings.Remove(existingStreaming);

            await _context.SaveChangesAsync();
            return existingStreaming;
        }

        public async Task<Streaming?> UpdateAsync(int id, Streaming model)
        {
            var existingStreaming = await _context.Streamings.FirstOrDefaultAsync(m => m.Id == id);
            if (existingStreaming == null)
            {
                return null;
            }
            existingStreaming.Name = model.Name;

            await _context.SaveChangesAsync();
            return existingStreaming;
        }
        public Task<bool> StreamingExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}