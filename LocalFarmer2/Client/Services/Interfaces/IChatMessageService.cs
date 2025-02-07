namespace LocalFarmer2.Client.Services;

public interface IChatMessageService
{
    public Task<List<ChatMessage>> GetChatMessages(string IdUserSender, string  IdUserReceiver);
}