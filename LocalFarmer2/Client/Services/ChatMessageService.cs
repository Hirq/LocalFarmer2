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

    public async Task<List<ChatMessage>> GetChatMessages(string IdUserSender, string IdUserReceiver)
    {
        var queryParams = $"?IdUserSender={IdUserSender}&IdUserReceiver={IdUserReceiver}";
        var messages = await _http.GetFromJsonAsync<List<ChatMessage>>($"api/ChatMessage/GetMessages{queryParams}");

        return messages;
    }
}