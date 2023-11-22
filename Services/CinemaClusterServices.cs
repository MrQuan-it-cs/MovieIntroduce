using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieIntroduce.Models;


namespace MovieIntroduce.Services
{
    public class CinemaClusterServices
    {
        public readonly IMongoCollection<CinemaClusters> _cinemaCluster;
        public CinemaClusterServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _cinemaCluster = database.GetCollection<CinemaClusters>(mongoDBSettings.Value.CinemaClusterCollection);
        }
        public async Task<IEnumerable<CinemaClusters>> Get()
        {
            
            //return await _cinemaCluster.Find(actor => true).Skip(skip).Limit(limit).ToListAsync();

            BsonDocument[] pipeline = new BsonDocument[] {Lookup.cinemaclusters_lookup_cinemaimages, Lookup.cinemaclusters_lookup_fareimages, Lookup.cinemaclusters_lookup_cinemas };

            return await _cinemaCluster.Aggregate<CinemaClusters>(pipeline).ToListAsync();
        }
        public async Task<IEnumerable<CinemaClusters>> GetById(string id)
        {
            BsonDocument match = new BsonDocument 
            {
                {"$match", new BsonDocument{ 
                    { "_id", new ObjectId(id) } 
                }}
            };
            BsonDocument[] pipeline = new BsonDocument[] {match, Lookup.cinemaclusters_lookup_cinemaimages, Lookup.cinemaclusters_lookup_fareimages, Lookup.cinemaclusters_lookup_cinemas };

            return await _cinemaCluster.Aggregate<CinemaClusters>(pipeline).ToListAsync();
            //return await _cinemaCluster.Find(cinema => cinema.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CinemaClusters>> GetByName(string nameSearch, int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _cinemaCluster.Find(cinema => cinema.CinemaClusterName.Contains(nameSearch) && cinema.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
    }
}
