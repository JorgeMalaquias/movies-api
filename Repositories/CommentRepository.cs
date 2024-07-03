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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetManyAsync()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }
        public async Task<Comment> CreateAsync(Comment model)
        {
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Comment?> DeleteAsync(int id, Comment model)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (existingComment == null)
            {
                return null;
            }
            _context.Comments.Remove(existingComment);

            await _context.SaveChangesAsync();
            return existingComment;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment model)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Content = model.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}