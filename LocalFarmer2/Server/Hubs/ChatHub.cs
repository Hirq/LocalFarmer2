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
            //var date = DateTime.Now.ToShortTimeString();
            //var time = DateTime.Now.ToShortTimeString();

            var users = new string[]
            {
                dto.IdUserSender,
                dto.IdUserReceiver
            };

            //List<string> users2 = new List<string>()
            //{
            //    "53898801-370c-4fbc-a99c-86243f159fe5",
            //    "8e339c44-2ccf-4e17-b774-626a7c9c8c1b"
            //};
            
            await Clients.Users(users).SendAsync("ReceiveMessage", dto);
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
