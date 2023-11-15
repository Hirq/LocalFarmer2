using LocalFarmer2.Server.Data;

namespace LocalFarmer2.Server.Repositories
{
    public class FarmhouseRepository : BaseRepository<Farmhouse>, IFarmhouseRepository
    {
        public FarmhouseRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
