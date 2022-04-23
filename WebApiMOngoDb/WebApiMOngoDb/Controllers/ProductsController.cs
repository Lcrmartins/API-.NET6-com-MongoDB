using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMOngoDb.Models;
using WebApiMOngoDb.Services;

namespace WebApiMOngoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductsController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
            => await _productServices.GetProductsAsync();

        [HttpGet("{id}")]
        public async Task<Product> GetProductById(string id)
            => await _productServices.GetProductByIdAsync(id);

        [HttpPost]
        public async Task<Product> PostProductAsync(Product product)
        {
            await _productServices.CreateProductAsync(product);
            return product;
        }

        [HttpPut]
        public async Task<Product> UpdateProductAsync(Product product)
        {
            await _productServices.UpdateProductAsync(product);
            return product;
        }

        [HttpDelete]
        public async Task<string> DeleteProductAsync(string id)
            => await _productServices.RemoveProductAsync(id);
    }
}
