using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> CreateAsync(Genre model);
    }
}