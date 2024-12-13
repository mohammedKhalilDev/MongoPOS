using MongoDB.Driver;
using MongoPOS.Models;

namespace MongoPOS.Db
{
    public class POSDbContext
    {
        private readonly IMongoDatabase _database;

        public POSDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDBSettings:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDBSettings:DatabaseName"]);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");

    }
}
