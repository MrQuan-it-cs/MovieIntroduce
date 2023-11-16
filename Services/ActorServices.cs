using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieIntroduce.Models;

namespace MovieIntroduce.Services
{
    public class ActorServices
    {
        private readonly IMongoCollection<Actors> _actors;
        public ActorServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _actors = database.GetCollection<Actors>(mongoDBSettings.Value.ActorCollection);
        }
        public async Task<List<Actors>> Get(int page, int limit)
        {
            var skip = (page - 1) * limit;
            var totalPage = Math.Ceiling(await _actors.CountDocumentsAsync(actor => true) / (decimal)limit);
            return await _actors.Find(actor => true && actor.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
        public async Task<List<Actors>> GetByName(string nameSearch, int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _actors.Find(actor => actor.ActorName.Contains(nameSearch) && actor.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
    }
}
