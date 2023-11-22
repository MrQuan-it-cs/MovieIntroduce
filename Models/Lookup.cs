using MongoDB.Bson;

namespace MovieIntroduce.Models
{
    public class Lookup
    {
        public static BsonDocument actor_lookup = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","Image" },
                {"foreignField","_id" },
                {"as","Image_details" },
            }}
        };
    }
}
