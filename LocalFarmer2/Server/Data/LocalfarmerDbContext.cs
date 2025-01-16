using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalFarmer2.Server.Data
{
    public class LocalfarmerDbContext : IdentityDbContext<IdentityUser>
    {
        public LocalfarmerDbContext(DbContextOptions<LocalfarmerDbContext> options) : base(options)
        {
        }

        public DbSet<Farmhouse> Farmhouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<FavoriteFarmhouse> FavoritesFarmhouses { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
