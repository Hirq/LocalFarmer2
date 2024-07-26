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
            var result = await _http.GetFromJsonAsync<List<Product>>("api/Product/ListProducts");

            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
        }

        public async Task<List<Product>> GetProductsFarmhouse(int idFarmhouse)
        {
            var result = await _http.GetFromJsonAsync<List<Product>>($"api/Product/ListProductsFarmhouse/{idFarmhouse}");

            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
        }

        public async Task<List<Product>> GetRandomProductsFarmhouse(int idFarmhouse, int withoutProductId, int count)
        {
            var result = await _http.GetFromJsonAsync<List<Product>>($"api/Product/ListProductsFarmhouse/{idFarmhouse}");
            
            if (result == null)
            {
                throw new Exception("Not found products");
            }
            
            Random rng = new Random();
            var shuffledcards = result.Where(x => x.Id != withoutProductId).OrderBy(_ => rng.Next()).ToList();

            var resultCount = shuffledcards.Take(count);

            return resultCount.ToList();
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<Product>($"api/Product/Product/{id}");

            if (result == null)
            {
                throw new Exception("Not found products");
            }

            return result;
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
