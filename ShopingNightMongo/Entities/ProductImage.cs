﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShopingNightMongo.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
    }
}
