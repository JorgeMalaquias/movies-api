using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Models;

namespace movies_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment model);
        Task<Comment?> GetByIdAsync(int id);
    }
}