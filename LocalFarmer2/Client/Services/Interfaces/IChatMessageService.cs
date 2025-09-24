namespace LocalFarmer2.Client.Services;

public interface IChatMessageService
{
    Task<List<ChatMessageDto>> GetChatMessages(string idUserSender, string idUserReceiver);
    Task<ChatLastMessageDto> GetLastChatMessage(string idUserSender, string idUserReceiver);
    Task<List<ChatLastMessageDto>> GetLastChatMessages(string idUserSender, List<string> idsUserReceiver);
    Task<List<ChatUserKeyDto>> GetUserChats(string idUser);
    Task<int> GetUnreadCountForUser(string idUser);
    Task MarkConversationAsRead(string idUserReader, string idUserOther);
}