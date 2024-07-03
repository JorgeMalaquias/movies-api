using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<EntityEntry<Streaming>> CreateAsync(Streaming model)
        {
            var newStreaming = await _context.Streamings.AddAsync(model);
            await _context.SaveChangesAsync();
            return newStreaming;
        }


    }
}