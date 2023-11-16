using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieIntroduce.Models
{
    public class Actors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Image")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Image { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("ActorName")]
        public string ActorName { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("__v")]
        public int __v { get; set; }
    }
}
