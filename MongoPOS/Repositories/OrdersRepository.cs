using MongoDB.Driver;
using MongoPOS.Db;
using MongoPOS.Models;

namespace MongoPOS.Repositories
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(string id);
        Task CreateOrderAsync(Order Order);
        Task UpdateOrderAsync(string id, Order updatedOrder);
        Task DeleteOrderAsync(string id);
    }

    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrdersRepository(POSDbContext context)
        {
            _orders = context.Orders;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orders.Find(_ => true).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orders.InsertOneAsync(order);
        }

        public async Task UpdateOrderAsync(string id, Order updatedOrder)
        {
            await _orders.ReplaceOneAsync(o => o.Id == id, updatedOrder);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _orders.DeleteOneAsync(o => o.Id == id);
        }
    }

}
