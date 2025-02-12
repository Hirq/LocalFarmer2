using LocalFarmer2.Server.Repositories.Interfaces;

namespace LocalFarmer2.Server.Repositories
{
    public class ChatUserKeyRepository : BaseRepository<ChatUserKey>, IChatUserKeyRepository
    {
        public ChatUserKeyRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
