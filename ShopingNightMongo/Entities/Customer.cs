using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShopingNightMongo.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
