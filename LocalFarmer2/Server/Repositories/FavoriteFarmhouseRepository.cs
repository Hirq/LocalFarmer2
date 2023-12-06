using LocalFarmer2.Server.Data;

namespace LocalFarmer2.Server.Repositories
{
    public class FavoriteFarmhouseRepository : BaseRepository<FavoriteFarmhouse>, IFavoriteFarmhouseRepository
    {
        public FavoriteFarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
