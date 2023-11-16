using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieIntroduce.Models
{
    public class Cinemas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("CinemaName")]
        public string CinemaName { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }
    }
}
