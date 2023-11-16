using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MovieIntroduce.Models
{
    public class CinemaClusters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Cinemas")]
        public List<ObjectId> Cinemas { get; set; }

        [BsonElement("CinemaImage")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CinemaImage { get; set; }

        [BsonElement("FareImage")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FareImage { get; set; }

        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }

        [BsonElement("CinemaClusterName")]
        public string CinemaClusterName { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Hotline")]
        public int Hotline { get; set; }

        [BsonElement("Website")]
        public string Website { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("__v")]
        public int __v { get; set; }
    }
}
