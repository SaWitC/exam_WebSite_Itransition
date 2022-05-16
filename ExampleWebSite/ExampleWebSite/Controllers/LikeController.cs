using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Controllers
{
    public class LikeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILikeRepository _like;
        private readonly IItemRepository _item;
        public LikeController(UserManager<User> userManger,ILikeRepository like,IItemRepository item)
        {
            _userManager = userManger;
            _like = like;
            _item = item;
        }
        [Authorize]
        public async Task<ReturnLikeViewModel> Like(int? ItemId)
        {

            ReturnLikeViewModel returnLikeViewModel = new ReturnLikeViewModel();
            if (ItemId != null)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ItemModel item = _item.GetItemById((int)ItemId);

                LikeModel like = _like.GetLike(user,item);
                if (like != null)returnLikeViewModel= await _like.ChangeLikeAsync(like,item);
                else await _like.LikeAsync(user,item);
                return returnLikeViewModel;
            }
            returnLikeViewModel.Message = "Error";
            return returnLikeViewModel;
        }
        
    }
}
