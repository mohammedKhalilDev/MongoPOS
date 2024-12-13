using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoPOS.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("products")]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
