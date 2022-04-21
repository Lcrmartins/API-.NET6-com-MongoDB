using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMOngoDb.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
