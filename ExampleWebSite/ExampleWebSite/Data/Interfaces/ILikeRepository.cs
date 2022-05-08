using ExampleWebSite.Models;
using ExampleWebSite.ViewModels.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface ILikeRepository
    {
        public Task<ReturnLikeViewModel> LikeAsync(User user,ItemModel item);
        //public Task LikeAsync(string user, int itemId);
        public Task<ReturnLikeViewModel> ChangeLikeAsync(LikeModel like, ItemModel item);
        public Task<bool> TryLikeAsync(LikeModel like);
        public LikeModel GetLike(User user, ItemModel item);

    }
}
