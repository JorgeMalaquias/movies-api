using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IStreamingRepository
    {
        Task<EntityEntry<Streaming>> CreateAsync(Streaming model);
    }
}