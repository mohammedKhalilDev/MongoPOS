using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoPOS
{
    public class DatabaseInitializer
    {


        public async Task InitializeDatabaseAsync(IMongoDatabase database)
        {
            var productCommand = new BsonDocument
                {
                    { "create", "Products" },
                    { "validator", new BsonDocument
                        {
                            { "$jsonSchema", new BsonDocument
                                {
                                    { "bsonType", "object" },
                                    { "required", new BsonArray { "barcode", "name", "category", "price", "isAvailable" } },
                                    { "properties", new BsonDocument
                                        {
                                            { "barcode", new BsonDocument
                                                {
                                                    { "bsonType", "string" },
                                                    { "description", "Barcode is required and must be a string" }
                                                }
                                            },
                                            { "name", new BsonDocument
                                                {
                                                    { "bsonType", "string" },
                                                    { "description", "Name is required and must be a string" }
                                                }
                                            },
                                            { "category", new BsonDocument
                                                {
                                                    { "bsonType", "string" },
                                                    { "description", "Category is required and must be a string" }
                                                }
                                            },
                                            { "price", new BsonDocument
                                                {
                                                    { "bsonType", "decimal" },
                                                    { "minimum", 0 },
                                                    { "description", "Price must be a non-negative decimal" }
                                                }
                                            },
                                            { "isAvailable", new BsonDocument
                                                {
                                                    { "bsonType", "bool" },
                                                    { "description", "isAvailable is required and must be a boolean" }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            var orderCommand = new BsonDocument
            {
                { "create", "Orders" },
                { "validator", new BsonDocument
                    {
                        { "$jsonSchema", new BsonDocument
                            {
                                { "bsonType", "object" },
                                { "required", new BsonArray { "date", "products" } },
                                { "properties", new BsonDocument
                                    {
                                        { "date", new BsonDocument
                                            {
                                                { "bsonType", "date" },
                                                { "description", "Date is required and must be a valid date" }
                                            }
                                        },
                                        { "products", new BsonDocument
                                            {
                                                { "bsonType", "array" },
                                                { "items", new BsonDocument
                                                    {
                                                        { "bsonType", "object" },
                                                        { "required", new BsonArray { "barcode", "name", "category", "price", "isAvailable" } },
                                                        { "properties", new BsonDocument
                                                            {
                                                                { "barcode", new BsonDocument
                                                                    {
                                                                        { "bsonType", "string" },
                                                                        { "description", "Barcode is required and must be a string" }
                                                                    }
                                                                },
                                                                { "name", new BsonDocument
                                                                    {
                                                                        { "bsonType", "string" },
                                                                        { "description", "Name is required and must be a string" }
                                                                    }
                                                                },
                                                                { "category", new BsonDocument
                                                                    {
                                                                        { "bsonType", "string" },
                                                                        { "description", "Category is required and must be a string" }
                                                                    }
                                                                },
                                                                { "price", new BsonDocument
                                                                    {
                                                                        { "bsonType", "decimal" },
                                                                        { "minimum", 0 },
                                                                        { "description", "Price must be a non-negative decimal" }
                                                                    }
                                                                },
                                                                { "isAvailable", new BsonDocument
                                                                    {
                                                                        { "bsonType", "bool" },
                                                                        { "description", "isAvailable is required and must be a boolean" }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                },
                                                { "description", "Products is required and must be an array of valid Product objects" }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            if (!CollectionExists(database, "Products"))
            {
                await database.RunCommandAsync<BsonDocument>(productCommand);
            }

            if (!CollectionExists(database, "Orders"))
            {
                await database.RunCommandAsync<BsonDocument>(orderCommand);
            }
        }

        private bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var collections = database.ListCollections(new ListCollectionsOptions { Filter = filter });
            return collections.Any();
        }


    }
}
