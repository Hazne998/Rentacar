using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace RentaCar.Hubs
{
    public class MyHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.Name != null)
                await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }
    }
}
