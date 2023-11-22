using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieIntroduce.Models;

namespace MovieIntroduce.Services
{
    public class FilmServices
    {
        private readonly IMongoCollection<Films> _films;
        public FilmServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _films = database.GetCollection<Films>(mongoDBSettings.Value.FilmCollection);
        }
        public async Task<List<Films>> Get(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => true && film.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<Films> GetById(string id)
        {
            return await _films.Find(film => film.Id == id && film.IsDeleted == false).FirstOrDefaultAsync();
        }
        public async Task<List<Films>> GetFilmByGenre(int page, int limit, string genre)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.Genres.Contains(genre)).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetNewFilms(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film =>  film.IsNewFilm == true && film.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetNotNewFilms(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.IsNewFilm == false && film.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetHotFilms(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.IsHotFilm == true && film.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetNotHotFilms(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.IsHotFilm == false && film.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetInTheatreFilms(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.IsShowing == true && film.IsDeleted == false && film.ReleaseDate <= DateTime.Now).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetIncomingFilms(int page, int limit, string textSearch)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.FilmName.Contains(textSearch) && film.IsDeleted == false && film.ReleaseDate >= DateTime.Now).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Films>> GetFilmByName(int page, int limit, string textSearch)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _films.CountDocumentsAsync(film => true) / (decimal)limit);
            return await _films.Find(film => film.FilmName.Contains(textSearch)).Skip(skip).Limit(limit).ToListAsync();
        }
    }
}
