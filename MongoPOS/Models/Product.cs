﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoPOS.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("barcode")]
        public string Barcode { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
