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
        Console.WriteLine("idUserSender: " + idUserSender);
        Console.WriteLine("idUserReceiver: " + idUserReceiver);
        var messages = await _http.GetFromJsonAsync<List<ChatMessageDto>>($"api/ChatMessage/GetMessages?idUserSender={idUserSender}&idUserReceiver={idUserReceiver}");

        return messages;
    }

    public async Task<ChatDisplayMessageDto> GetChatMessages2(string idUserSender, string idUserReceiver)
    {
        var messages = await _http.GetFromJsonAsync<ChatDisplayMessageDto>($"api/ChatMessage/GetMessages2?idUserSender={idUserSender}&idUserReceiver={idUserReceiver}");

        return messages;
    }
}