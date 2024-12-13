namespace MongoPOS.Services
{

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task AddProductAsync(Product patient);
        Task UpdateProductAsync(string id, Product updatedProduct);
        Task DeleteProductAsync(string id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductsRepository _repository;

        public ProductService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product patient)
        {
            await _repository.CreateProductAsync(patient);
        }

        public async Task UpdateProductAsync(string id, Product updatedProduct)
        {
            await _repository.UpdateProductAsync(id, updatedProduct);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _repository.DeleteProductAsync(id);
        }
    }

}
