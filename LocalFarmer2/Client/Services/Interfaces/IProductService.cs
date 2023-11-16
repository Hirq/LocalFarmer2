using LocalFarmer2.Shared.DTOs;
using LocalFarmer2.Shared.Models;

namespace LocalFarmer2.Client.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<List<Product>> GetProductsFarmhouse(int idFarmhouse);
        public Task<Product> GetProduct(int id);
        public Task AddProduct(ProductDto dto, int idFarmhouse);
        public Task EditProduct(ProductDto dto, int idProduct);
        public Task DeleteProduct(int idProduct);
    }
}
