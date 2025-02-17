namespace LocalFarmer2.Client.Services;

public interface IChatMessageService
{
    public Task<List<ChatMessageDto>> GetChatMessages(string idUserSender, string idUserReceiver);
    public Task<ChatDisplayMessageDto> GetChatMessages2(string idUserSender, string idUserReceiver);
}