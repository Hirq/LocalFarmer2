namespace LocalFarmer2.Server.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(LocalfarmerDbContext context) : base(context)
        {
        }
    }
}
