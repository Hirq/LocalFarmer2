using LocalFarmer2.Server.Repositories.Interfaces;

namespace LocalFarmer2.Server.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IMapper _mapper;


        public ChatMessageService(IChatMessageRepository chatMessageRepository, IMapper mapper)
        {
            _chatMessageRepository = chatMessageRepository;
            _mapper = mapper;
        }

        public async Task<List<ChatMessage>> GetMessages(string  idUserSender, string idUserReceiver)
        {
            var iSent = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == idUserSender && x.IdUserReceiver == idUserReceiver)).ToList();
            var iReceived = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == idUserReceiver && x.IdUserReceiver == idUserSender)).ToList();
            var allMessages = new List<ChatMessage>();
            allMessages.AddRange(iSent);
            allMessages.AddRange(iReceived);
            await _chatMessageRepository.SaveChangesAsync();

            return allMessages.ToList();
        }

        public async Task<ChatMessage> SendMessage(ChatMessageDto dto)
        {
            var message = _mapper.Map<ChatMessage>(dto);
            message.EncryptedMessage = new byte[1];
            message.MessageIV = new byte[0];
            message.DateSent = DateTime.Now;
            await _chatMessageRepository.AddAsync(message);
            await _chatMessageRepository.SaveChangesAsync();

            return message;
        }
    }
}
