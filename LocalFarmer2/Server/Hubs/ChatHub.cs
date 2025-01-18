using LocalFarmer2.Server.Repositories.Interfaces;
using LocalFarmer2.Server.Services;
using Microsoft.AspNetCore.SignalR;

namespace LocalFarmer2.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatMessageService _chatMessageService;
        public ChatHub(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public async Task SendMessage(ChatMessageDto dto)
        {
            var message = await _chatMessageService.SendMessage(dto);

            List<string> users = new List<string>()
            {
                message.IdUserSender,
                message.IdUserReceiver
            };
            
            await Clients.Users(users).SendAsync("ReceiveMessage", users, dto.Message);
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
