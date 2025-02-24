using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Services
{
    public interface IChatMessageService
    {
        Task<List<ChatMessageDto>> GetMessages(string  idUserSender, string idUserReceiver);
        Task<ChatMessage> SendMessage(ChatMessageDto dto);
        Task<byte[]> GetOrCreateKey(string user1, string user2);
        Task<List<ChatUserKey>> GetChatUserKeys(string idUser);
    }
}
