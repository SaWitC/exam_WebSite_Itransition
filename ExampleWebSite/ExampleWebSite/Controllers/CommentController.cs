using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Components;
using ExampleWebSite.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ExampleWebSite.ViewModels.Comments;
using ExampleWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using ExampleWebSite.Hubs;

namespace ExampleWebSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _comment;
        private readonly IItemRepository _item;
        private readonly ICollectionRepository _collection;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<CommentHub> _hubContext;

        public CommentController(ICommentRepository comment,ICollectionRepository collection,UserManager<User> userManager, IItemRepository item,IHubContext<CommentHub> hub)
        {
            _item = item;
            _comment = comment;
            _collection = collection;
            _userManager = userManager;
            _hubContext = hub;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComent(string message,int itemId)
        {
            if (message!=null &&itemId>0)
            {
                if (message.Length > 20)
                {
                    CommentModel commentModel = new CommentModel();
                    commentModel.Message = message;
                    commentModel.Item = _item.GetItemById(itemId);
                    commentModel.Avtor = await _userManager.FindByNameAsync(User.Identity.Name);
                    await _comment.CreateCommentAsync(commentModel);

                    await _hubContext.Clients.All.SendAsync("comment"+itemId.ToString(), message);
                    return Ok();
                }
                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
