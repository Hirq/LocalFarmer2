using LocalFarmer2.Server.Data;
using LocalFarmer2.Server.Models;

namespace LocalFarmer2.Server.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
