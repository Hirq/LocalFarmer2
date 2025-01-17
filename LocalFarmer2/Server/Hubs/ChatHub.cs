using Microsoft.AspNetCore.SignalR;

namespace LocalFarmer2.Server.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
               
        }

        public async Task SendMessage(string user, string message)
        {
            string senderId = "";
            string receiverId = "";

            List<string> users = new List<string>()
            {
                senderId,
                receiverId
            };

            
            await Clients.Users(users).SendAsync("ReceiveMessage", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
