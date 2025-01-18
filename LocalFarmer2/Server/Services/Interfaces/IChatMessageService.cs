using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Services
{
    public interface IChatMessageService
    {
        Task<List<ChatMessage>> GetMessages(ChatMessageDto dto);
        Task<ChatMessage> SendMessage(ChatMessageDto dto);
    }
}
