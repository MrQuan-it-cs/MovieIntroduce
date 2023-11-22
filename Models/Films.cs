using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MovieIntroduce.Models
{
    public class Films
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Actors")]
        public List<ObjectId> Actors { get; set; }

        [BsonElement("Cinemas")]
        public List<ObjectId> Cinemas { get; set; }

        [BsonElement("Genres")]
        public string[] Genres { get; set; }

        [BsonElement("CoverImage")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CoverImage { get; set; }

        [BsonElement("Images")]
        public List<ObjectId> Images { get; set; }

        [BsonElement("isHotFilm")]
        public bool IsHotFilm { get; set; }

        [BsonElement("isNewFilm")]
        public bool IsNewFilm { get; set; }

        [BsonElement("isShowing")]
        public bool IsShowing { get; set; }

        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }

        [BsonElement("Score")]
        public List<Object> Score { get; set; }

        [BsonElement("FilmName")]
        public string FilmName { get; set; }

        [BsonElement("Director")]
        public string Director { get; set; }

        [BsonElement("Writer")]
        public string Writer { get; set; }

        [BsonElement("Production")]
        public string Production { get; set; }

        [BsonElement("RunningTime")]
        public int RunningTime { get; set; }

        [BsonElement("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("ReviewContent")]
        public string ReviewContent { get; set; }

        [BsonElement("Rated")]
        public string Rated { get; set; }

        [BsonElement("National")]
        public string National { get; set; }

        [BsonElement("TrailerUrl")]
        public string TrailerUrl { get; set; }

        [BsonElement("__v")]
        public int __v { get; set; }

        [BsonElement("PosterImage")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PosterImage { get; set; }

        [BsonElement("ReviewImage")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewImage { get; set; }



        public List<Images> CoverImage_details { get; set; }
        public List<Images> Image_details { get; set; }
        public List<Images> PosterImage_details { get; set; }
        public List<Images> ReviewImage_details { get; set; }
        public List<Cinemas> Cinema_details { get; set; }
        public List<Actors> Actor_details { get; set; }

    }
}
