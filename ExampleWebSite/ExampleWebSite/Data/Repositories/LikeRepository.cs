using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ExamWebSiteDBContext _context;
        public LikeRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public async Task<ReturnLikeViewModel> LikeAsync(User user, ItemModel item)
        {
            if (user!=null&&item!=null&&item.Id!=0)
            {
                ReturnLikeViewModel returnLike = new ReturnLikeViewModel();

                LikeModel like = new LikeModel();
                like.Item = item;
                like.User = user;
                like.IsLiked = true;
                await _context.Likes.AddAsync(like);
                item.likesCount += 1;
                _context.Items.Update(item);
                await _context.SaveChangesAsync();

                returnLike.Count = item.likesCount;
                returnLike.Status = like.IsLiked;

                return returnLike;
            }
            return null;
        }
        public async Task<ReturnLikeViewModel> ChangeLikeAsync(LikeModel like,ItemModel item)
        {
            if (like != null && item != null && item.Id != 0)
            {
                ReturnLikeViewModel returnLike = new ReturnLikeViewModel();
                if (like.IsLiked)
                {
                    like.IsLiked = false;
                    item.likesCount -= 1;
                    returnLike.Count = item.likesCount;
                    returnLike.Status = like.IsLiked;
                }
                else
                {
                    like.IsLiked = true;
                    item.likesCount += 1;
                    returnLike.Count = item.likesCount;
                    returnLike.Status = like.IsLiked;
                }
                _context.Likes.Update(like);
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return returnLike;
            }
            return null;
        }

        public async Task<bool> TryLikeAsync(LikeModel like)
        {
            var LikeModel = _context.Likes.FirstOrDefault(o => o.Id == like.Id);
            if (LikeModel != null)
            {
                LikeModel.IsLiked = true;
                _context.Likes.Update(LikeModel);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public LikeModel GetLike(User user,ItemModel item)
        {
            if (user != null && item != null)
            {
                var like = _context.Likes.FirstOrDefault(o => o.User == user && o.Item == item);
                if (like != null) return like;
                else return null;
            }
            return null;
        }
    }
}
