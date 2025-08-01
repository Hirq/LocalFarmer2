using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet, Route("ListProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllAsync
            (
                whereExpression: p => true,
                includeProperties: p => p.Farmhouse
            );

            return Ok(products);
        }

        [HttpGet, Route("Product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product product = await _productRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet, Route("ListProductsFarmhouse/{idFarmhouse}")]
        public async Task<IActionResult> GetProductsFarmhouse(int idFarmhouse)
        {
            var products = await _productRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse);

            return Ok(products);
        }

        [HttpGet, Route("ListProductsWithoutFarmhouse/{idFarmhouse}")]
        public async Task<IActionResult> ListProductsWithoutFarmhouse(int idFarmhouse)
        {
            var products = await _productRepository.GetAllAsync(x => x.IdFarmhouse != idFarmhouse);

            return Ok(products);
        }

        [HttpPost, Route("AddProduct/{idFarmhouse}")]
        public async Task<IActionResult> AddProduct(ProductDto dto, int idFarmhouse)
        {
            Product product = _mapper.Map<Product>(dto);

            product.IdFarmhouse = idFarmhouse;

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut, Route("EditProduct/{idProduct}")]
        public async Task<IActionResult> EditProduct(ProductDto dto, int idProduct)
        {
            var product = await _productRepository.GetFirstOrDefaultAsync(x => x.Id == idProduct);
            Product newProduct = _mapper.Map<Product>(dto);

            if (idProduct != 0)
            {
                newProduct.Id = idProduct;
                newProduct.IdFarmhouse = product.IdFarmhouse;
            }

            _productRepository.Update(newProduct);
            await _productRepository.SaveChangesAsync();

            return Ok(newProduct);
        }

        [HttpDelete, Route("DeleteProduct/{idProduct}")]
        public async Task<IActionResult> DeleteProduct(int idProduct)
        {
            var product = await _productRepository.GetFirstOrDefaultAsync(x => x.Id == idProduct);

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();

            return Ok();
        }
    }
}