using MongoDB.Driver;
using MovieIntroduce.Models;
using Microsoft.Extensions.Options;

namespace MovieIntroduce.Services
{
    public class CinemaServices
    {
        private readonly IMongoCollection<Cinemas> _cinemas;

        public CinemaServices(IOptions<MongoDBSettings> mongoDBSettings) {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _cinemas = database.GetCollection<Cinemas>(mongoDBSettings.Value.CinemaCollection);
        }
        public async Task<List<Cinemas>> Get(int page, int limit)
        {
            var skip = (page-1) * limit;
            var totalPage = Math.Ceiling(await _cinemas.CountDocumentsAsync(cinema => true)/(decimal)limit);
            return await _cinemas.Find(cinema => true).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Cinemas>> GetByName(string nameSearch, int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _cinemas.Find(cinema => cinema.CinemaName.Contains(nameSearch) && cinema.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task CreateCinema(Cinemas cinema)
        {
            await _cinemas.InsertOneAsync(cinema);
            return;
        }
        public async Task DeleteCinema(string id)
        {
            FilterDefinition<Cinemas> filter = Builders<Cinemas>.Filter.Eq("Id",id);
            await _cinemas.DeleteOneAsync(filter);
            return;
        }
        public async Task UpdateCinema(string id,  Cinemas cinema)
        {
            FilterDefinition<Cinemas> filter = Builders<Cinemas>.Filter.Eq("Id", id);
            UpdateDefinition<Cinemas> update = Builders<Cinemas>.Update
                .Set("IsDeleted", cinema.IsDeleted)
                .Set("CinemaName", cinema.CinemaName)
                .Set("Address", cinema.Address);
            await _cinemas.UpdateOneAsync(filter, update);
            return;
        }
    }
}
