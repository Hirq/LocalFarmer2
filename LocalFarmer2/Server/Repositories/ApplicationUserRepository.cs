using LocalFarmer2.Server.Data;

namespace LocalFarmer2.Server.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
