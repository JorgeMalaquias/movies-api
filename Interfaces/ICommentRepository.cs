using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Models;

namespace movies_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetManyAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment model);
        Task<Comment?> UpdateAsync(int id, Comment model);
        Task<Comment?> DeleteAsync(int id, Comment model);

    }
}