using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShopingNightMongo.Entities
{
    public class Galery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GaleryId { get; set; }
        public string GaleryTitle { get; set; }
        public string GalerySubtitle { get; set; }
        public string ImageUrl { get; set; }

    }
}
