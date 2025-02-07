using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Services
{
    public interface IChatMessageService
    {
        Task<List<ChatMessage>> GetMessages(string  IdUserSender, string IdUserReceiver);
        Task<ChatMessage> SendMessage(ChatMessageDto dto);
    }
}
