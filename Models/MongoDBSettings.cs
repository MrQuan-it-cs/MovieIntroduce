namespace MovieIntroduce.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CinemaCollection { get; set; } = null!;
        public string ActorCollection { get; set; } = null!;
        public string CinemaClusterCollection { get; set; } = null!;
        public string FilmCollection { get; set; } = null!;
        public string ImageCollection { get; set; } = null!;
    }
}
