using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Services
{
    public interface IChatMessageService
    {
        Task<List<ChatMessage>> GetMessages(string  idUserSender, string idUserReceiver);
        Task<ChatMessage> SendMessage(ChatMessageDto dto);
    }
}
