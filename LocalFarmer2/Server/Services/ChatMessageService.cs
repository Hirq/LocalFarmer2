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

        public async Task<List<ChatMessage>> GetMessages(ChatMessageDto dto)
        {
            //var iSent = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == dto.IdUserSender && x.IdUserReceiver == dto.IdUserReceiver));
            //var iReceived = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == dto.IdUserReceiver && x.IdUserReceiver == dto.IdUserSender));
            var allMessages = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == dto.IdUserSender && x.IdUserReceiver == dto.IdUserReceiver && x.IdUserSender == dto.IdUserReceiver && x.IdUserReceiver == dto.IdUserSender));
            await _chatMessageRepository.SaveChangesAsync();

            return allMessages.ToList();
        }

        public async Task<ChatMessage> SendMessage(ChatMessageDto dto)
        {
            var message = _mapper.Map<ChatMessage>(dto);
            await _chatMessageRepository.AddAsync(message);
            await _chatMessageRepository.SaveChangesAsync();

            return message;
        }
    }
}
