namespace LocalFarmer2.Client.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<List<Product>> GetProductsFarmhouse(int idFarmhouse);
        public Task<List<Product>> GetRandomProductsFarmhouse(int idFarmhouse, int withoutProductId, int count);
        public Task<Product> GetProduct(int id);
        public Task AddProduct(ProductDto dto, int idFarmhouse);
        public Task EditProduct(ProductDto dto, int idProduct);
        public Task DeleteProduct(int idProduct);
    }
}
