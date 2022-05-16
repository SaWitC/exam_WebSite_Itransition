using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface ICommentRepository
    {
        public IEnumerable<CommentModel> TakeCommentsByBlogId_Skip(int skip,int takeCount,int itemId);
        public Task CreateCommentAsync(CommentModel model);
        public Task EditCommentAsync(int CommentId);
        public Task DeleteCommentAsync(int CommentId);

    }
}
