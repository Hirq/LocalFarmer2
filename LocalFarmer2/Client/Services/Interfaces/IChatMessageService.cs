namespace LocalFarmer2.Client.Services;

public interface IChatMessageService
{
    Task<List<ChatMessageDto>> GetChatMessages(string idUserSender, string idUserReceiver);
    Task<List<ChatUserKeyDto>> GetUserChats(string idUser);
}