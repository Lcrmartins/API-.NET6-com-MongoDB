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

        public async Task<List<Product>> GetProductsAsync() => 
            await _productCollection.Find(x => true).ToListAsync();

        public async Task<Product> GetProductByIdAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<string> CreateProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            
            
            return product.Id;
        }





        public async void DeleteProductByIdAsync(string id) =>
            await _productCollection.DeleteOne<Product>
    }
}
