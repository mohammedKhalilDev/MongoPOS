using MongoDB.Driver;
using MongoPOS.Db;
using MongoPOS.Models;

namespace MongoPOS.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task CreateProductAsync(Product patient);
        Task UpdateProductAsync(string id, Product updatedPatient);
        Task DeleteProductAsync(string id);
    }

    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsRepository(POSDbContext context)
        {
            _products = context.Products;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _products.Find(patient => patient.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProductAsync(Product patient)
        {
            await _products.InsertOneAsync(patient);
        }

        public async Task UpdateProductAsync(string id, Product updatedPatient)
        {
            await _products.ReplaceOneAsync(patient => patient.Id == id, updatedPatient);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _products.DeleteOneAsync(patient => patient.Id == id);
        }
    }

}
