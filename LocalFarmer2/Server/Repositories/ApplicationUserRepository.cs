using LocalFarmer2.Server.Data;
using LocalFarmer2.Server.Models;

namespace LocalFarmer2.Server.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
