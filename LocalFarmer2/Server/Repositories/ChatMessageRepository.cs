using LocalFarmer2.Server.Repositories.Interfaces;

namespace LocalFarmer2.Server.Repositories
{
    public class ChatMessageRepository : BaseRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
