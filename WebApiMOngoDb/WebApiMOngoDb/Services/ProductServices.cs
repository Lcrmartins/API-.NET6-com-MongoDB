using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiMOngoDb.Models;

namespace WebApiMOngoDb.Services
{
    public class ProductServices
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductServices(IOptions<ProductDatabaseSettings> productServices)
        {
            var mongoClient = new MongoClient(productServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productServices.Value.DatabaseName);
            _productCollection = mongoDatabase.GetCollection<Product>
                (productServices.Value.ProductCollectionName);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productCollection.Find(x => true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> CreateProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            return product.Id ?? "The product creation failed. Please, try again later.";
        }

        public async Task<string> UpdateProductAsync(Product modifiedProduct)
        {
            var result = await _productCollection.ReplaceOneAsync(x => x.Id == modifiedProduct.Id, modifiedProduct);
            return result.ToString() ?? "The product update failed. Please, try again later.";
        }

        public async Task<string> RemoveProductAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);
            return result.ToString() ?? "The product delection failed. Please, try again later.";
        }
    }
}
