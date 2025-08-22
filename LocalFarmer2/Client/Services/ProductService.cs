using System;
using static MudBlazor.CategoryTypes;

namespace LocalFarmer2.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public ProductService(HttpClient http,
            IMapper mapper)
        {
            _http = http;
            _mapper = mapper;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; } = new Product();

        public async Task<List<Product>> GetProducts()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/Product/ListProducts");
        }

        public async Task<List<Product>> GetProductsFarmhouse(int idFarmhouse)
        {
            return await _http.GetFromJsonAsync<List<Product>>($"api/Product/ListProductsFarmhouse/{idFarmhouse}");
        }

        public async Task<List<Product>> GetProductsWithoutFarmhouse(int idFarmhouse)
        {
            return await _http.GetFromJsonAsync<List<Product>>($"api/Product/ListProductsWithoutFarmhouse/{idFarmhouse}");
        }

        public async Task<List<Product>> GetRandomProductsFarmhouse(int idFarmhouse, int withoutProductId, int count)
        {
            Random rng = new Random();

            var products = await GetProductsFarmhouse(idFarmhouse);

            var shuffledProducts = products.Where(x => x.Id != withoutProductId).OrderBy(_ => rng.Next()).ToList();

            var chosenProducts = shuffledProducts.Take(count);

            return chosenProducts.ToList();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"api/Product/Product/{id}");
        }

        public async Task AddProduct(ProductDto dto, int idFarmhouse)
        {
            Product product = _mapper.Map<Product>(dto);
            await _http.PostAsJsonAsync($"api/Product/AddProduct/{idFarmhouse}", product);
        }

        public async Task EditProduct(ProductDto dto, int idProduct)
        {
            Product product = _mapper.Map<Product>(dto);
            await _http.PutAsJsonAsync($"api/Product/EditProduct/{idProduct}", product);
        }

        public async Task DeleteProduct(int idProduct)
        {
            await _http.DeleteAsync($"api/Product/DeleteProduct/{idProduct}");
        }
    }
}
