using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MovieIntroduce.Models
{
    public class Images
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("ImageName")]
        public string ImageName { get; set; }
        [BsonElement("Url")]
        public string Url { get; set; }
        [BsonElement("ImageId")]
        public string ImageId { get; set; }
        [BsonElement("__v")]
        public int __v { get; set; }

    }
}
