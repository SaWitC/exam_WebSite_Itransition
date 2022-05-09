using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Hubs
{
    public class CommentHub:Hub
    {
        public async Task SendComment(string Message,int itemId)
        {
            await Clients.All.SendAsync(itemId.ToString(),Message);
        }

        public override async Task OnConnectedAsync()
        {
            //await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync();
        }
    }
}
