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
            dto.DateSent = DateTime.Now;
            
            await Groups.AddToGroupAsync(Context.ConnectionId, dto.IdUserSender);
            await _chatMessageService.SendMessage(dto);
            await Clients.Group(dto.IdUserReceiver).SendAsync("ReceiveMessage", dto);
            await Clients.Group(dto.IdUserSender).SendAsync("ReceiveMessage", dto);
            //await Clients.All.SendAsync("ReceiveMessage", dto);
        }
    }
}
