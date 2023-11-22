using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieIntroduce.Models;
using System.Linq;

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
        public async Task<IEnumerable<Actors>> Get(int page, int limit)
        {
            var skip = (page - 1) * limit;
            //var totalPage = Math.Ceiling(await _actors.CountDocumentsAsync(actor => true) / (decimal)limit);
            //return await _actors.Find(actor => true && actor.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
            BsonDocument limitDoc = new BsonDocument
            {
                {"$limit",limit}
            };
            BsonDocument skipDoc = new BsonDocument
            {
                {"$skip",skip}
            };
            BsonDocument[] pipeline = new BsonDocument[] {skipDoc, limitDoc, Lookup.actor_lookup };

            return await _actors.Aggregate<Actors>(pipeline).ToListAsync();
        }
        public async Task<List<Actors>> GetByName(string nameSearch, int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _actors.Find(actor => actor.ActorName.Contains(nameSearch) && actor.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
    }
} 
