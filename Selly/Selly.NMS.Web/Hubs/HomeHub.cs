using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Selly.NMS.Web.Hubs
{
    public class HomeHub : Hub
    {
        public static HomeHub instance;
        public HomeHub()
        {
            instance = this;
        }

        public static List<string> ConnectedUsers;

        public async Task Send(string originatorUser, string message)
        {
            await Clients.All.SendAsync("messageReceived", originatorUser, message);
        }

        public void Connect(string newUser)
        {
        }
    }
}
