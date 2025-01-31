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
            await Groups.AddToGroupAsync(Context.ConnectionId, dto.IdUserSender);

            var message = await _chatMessageService.SendMessage(dto);
            //var date = DateTime.Now.ToShortTimeString();
            //var time = DateTime.Now.ToShortTimeString();

            var users = new string[]
            {
                dto.IdUserSender,
                dto.IdUserReceiver
            };

            await Clients.Group(dto.IdUserReceiver).SendAsync("ReceiveMessage", dto);
            await Clients.Group(dto.IdUserSender).SendAsync("ReceiveMessage", dto);
            //await Clients.All.SendAsync("ReceiveMessage", dto);
        }
    }
}
