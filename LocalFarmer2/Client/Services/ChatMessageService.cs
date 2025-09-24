using System.Net.Http;

namespace LocalFarmer2.Client.Services;

public class ChatMessageService : IChatMessageService
{
    private readonly HttpClient _http;
    private readonly IMapper _mapper;

    public ChatMessageService(HttpClient http, IMapper mapper)
    {
        _http = http;
        _mapper = mapper;
    }

    public async Task<List<ChatMessageDto>> GetChatMessages(string idUserSender, string idUserReceiver)
    {
        var messages = await _http.GetFromJsonAsync<List<ChatMessageDto>>($"api/ChatMessage/GetMessages?idUserSender={idUserSender}&idUserReceiver={idUserReceiver}");

        return messages;
    }

    public async Task<ChatLastMessageDto> GetLastChatMessage(string idUserSender, string idUserReceiver)
    {
        var message = await _http.GetFromJsonAsync<ChatLastMessageDto>($"api/ChatMessage/GetLastMessage?idUserSender={idUserSender}&idUserReceiver={idUserReceiver}");

        return message;
    }

    public async Task<List<ChatLastMessageDto>> GetLastChatMessages(string idUserSender, List<string> idsUserReceiver)
    {
        string queryString = string.Join("&", idsUserReceiver.Select(id => $"idsUserReceiver={id}"));
        var messages = await _http.GetFromJsonAsync<List<ChatLastMessageDto>>($"api/ChatMessage/GetLastMessages?idUserSender={idUserSender}&{queryString}");

        return messages;
    }

    public async Task<List<ChatUserKeyDto>> GetUserChats(string idUser)
    {
        var chats = await _http.GetFromJsonAsync<List<ChatUserKeyDto>>($"api/ChatMessage/GetUserChats?idUser={idUser}");

        return chats;
    }

    public async Task<int> GetUnreadCountForUser(string idUser)
    {
        var count = await _http.GetFromJsonAsync<int>($"api/ChatMessage/GetUnreadCountForUser?idUser={idUser}");
        return count;
    }

    public async Task MarkConversationAsRead(string idUserReader, string idUserOther)
    {
        await _http.PostAsync($"api/ChatMessage/MarkConversationAsRead?idUserReader={idUserReader}&idUserOther={idUserOther}", null);
    }
}