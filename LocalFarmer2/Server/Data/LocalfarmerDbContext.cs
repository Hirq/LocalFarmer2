using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalFarmer2.Server.Data
{
    public class LocalfarmerDbContext : IdentityDbContext
    {
        public LocalfarmerDbContext(DbContextOptions<LocalfarmerDbContext> options) : base(options)
        {
        }
    }
}
