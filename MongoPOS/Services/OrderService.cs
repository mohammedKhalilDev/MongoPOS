
using MongoDB.Driver;

namespace MongoPOS.Services
{
    public class OrderService
    {
        private readonly IOrdersRepository _repository;

        public OrderService(IOrdersRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _repository.GetOrderByIdAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _repository.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(string id, Order updatedOrder)
        {
            await _repository.UpdateOrderAsync(id, updatedOrder);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _repository.DeleteOrderAsync(id);
        }
    }

}
