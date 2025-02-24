using LocalFarmer2.Server.Repositories.Interfaces;
using System.Linq;
using System.Security.Cryptography;

namespace LocalFarmer2.Server.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IChatUserKeyRepository _chatUserKeyRepository;
        private readonly IMapper _mapper;


        public ChatMessageService(IChatMessageRepository chatMessageRepository, IChatUserKeyRepository chatUserKeyRepository, IMapper mapper)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatUserKeyRepository = chatUserKeyRepository;
            _mapper = mapper;
        }

        public async Task<List<ChatMessageDto>> GetMessages(string  idUserSender, string idUserReceiver)
        {
            List<ChatMessageDto> messagesEncrypted = new List<ChatMessageDto>();
            var iSent = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == idUserSender && x.IdUserReceiver == idUserReceiver)).ToList();
            var iReceived = (await _chatMessageRepository.GetAllAsync(x => x.IdUserSender == idUserReceiver && x.IdUserReceiver == idUserSender)).ToList();
            var allMessages = new List<ChatMessage>();
            allMessages.AddRange(iSent);
            allMessages.AddRange(iReceived);

            if(allMessages.Count > 0)
            {
                var key = await GetOrCreateKey(idUserSender, idUserReceiver);

                messagesEncrypted = allMessages.Select(x => new ChatMessageDto
                {
                    IdUserReceiver = x.IdUserReceiver,
                    IdUserSender = x.IdUserSender,
                    Message = AESHelper.Decrypt(x.EncryptedMessage, x.MessageIV, key),
                    DateSent = x.DateSent
                }).ToList();

                var days = allMessages.Select(x => (x.DateSent.Year, x.DateSent.Month, x.DateSent.Day)).Distinct();
                
                foreach (var day in days)
                {
                    messagesEncrypted.Add(new ChatMessageDto
                    {
                        Message = "Separator",
                        IsSeparator = true,
                        DateSent = new DateTime(day.Year, day.Month, day.Day)
                    });
                };

                messagesEncrypted = messagesEncrypted.OrderBy(x => x.DateSent).ToList();
            }

            return messagesEncrypted;
        }

        public async Task<byte[]> GetOrCreateKey(string user1, string user2)
        {
            var key = await _chatUserKeyRepository.GetFirstOrDefaultOrNullAsync(k =>
                (k.User1Id == user1 && k.User2Id == user2) || (k.User1Id == user2 && k.User2Id == user1));

            if (key == null)
            {
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.GenerateKey();
                    key = new ChatUserKey { User1Id = user1, User2Id = user2, AESKey = aes.Key };
                    await _chatUserKeyRepository.AddAsync(key);
                    await _chatUserKeyRepository.SaveChangesAsync();
                }
            }

            return key.AESKey;
        }

        public async Task<ChatMessage> SendMessage(ChatMessageDto dto)
        {
            var key = await GetOrCreateKey(dto.IdUserSender, dto.IdUserReceiver);

            var (encryptedMessage, iv) = AESHelper.Encrypt(dto.Message, key);

            var message = _mapper.Map<ChatMessage>(dto);
            message.EncryptedMessage = encryptedMessage;
            message.MessageIV = iv;

            await _chatMessageRepository.AddAsync(message);
            await _chatMessageRepository.SaveChangesAsync();

            return message;
        }

        public async Task<List<ChatUserKey>> GetChatUserKeys(string idUser)
        {
            var result = (await _chatUserKeyRepository.GetAllAsync(x => x.User1Id == idUser || x.User2Id == idUser)).ToList();

            return result;
        }

    }
}
