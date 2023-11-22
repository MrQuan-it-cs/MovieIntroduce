using MongoDB.Bson;

namespace MovieIntroduce.Models
{
    public class Lookup
    {
        //actor
        public static BsonDocument actor_lookup = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","Image" },
                {"foreignField","_id" },
                {"as","Image_details" },
            }}
        };

        //cinema_cluster
        public static BsonDocument cinemaclusters_lookup_cinemas = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","cinemas" },
                {"localField","Cinemas" },
                {"foreignField","_id" },
                {"as","Cinema_details" },
            }}
        };
        public static BsonDocument cinemaclusters_lookup_cinemaimages = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","CinemaImage" },
                {"foreignField","_id" },
                {"as","CinemaImage_details" },
            }}
        };
        public static BsonDocument cinemaclusters_lookup_fareimages = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","FareImage" },
                {"foreignField","_id" },
                {"as","FareImage_details" },
            }}
        };



        //films
        public static BsonDocument film_lookup_coverimage = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","CoverImage" },
                {"foreignField","_id" },
                {"as","CoverImage_details" },
            }}
        };
        public static BsonDocument film_lookup_images = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","Images" },
                {"foreignField","_id" },
                {"as","Image_details" },
            }}
        };
        public static BsonDocument film_lookup_posterimage = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","PosterImage" },
                {"foreignField","_id" },
                {"as","PosterImage_details" },
            }}
        };
        public static BsonDocument film_lookup_reviewimage = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","images" },
                {"localField","ReviewImage" },
                {"foreignField","_id" },
                {"as","ReviewImage_details" },
            }}
        };
        public static BsonDocument film_lookup_cinemas = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","Cinemas" },
                {"localField","ReviewImage" },
                {"foreignField","_id" },
                {"as","Cinema_details" },
            }}
        };
        public static BsonDocument film_lookup_actors = new BsonDocument
        {
            {"$lookup",new BsonDocument{
                {"from","Actors" },
                {"localField","ReviewImage" },
                {"foreignField","_id" },
                {"as","Actor_details" },
            }}
        };
    }
}
