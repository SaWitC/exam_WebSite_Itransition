using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebSite.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ExamWebSiteDBContext _context;
        public CommentRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public async Task CreateCommentAsync(CommentModel model)
        {
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int CommentId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(o=>o.Id==CommentId);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditCommentAsync(int CommentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CommentModel> TakeCommentsByBlogId_Skip(int skip,int takeCount, int itemId)
        {
            var comments = _context.Comments.Skip(skip).Where(o => o.ItemId== itemId).Take(takeCount).AsQueryable();
            return comments;
        }
    }
}
