using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieIntroduce.Models;
using System.Collections.Generic;

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
        public async Task<IEnumerable<CinemaClusters>> Get(int page, int limit)
        {
            var skip = (page - 1) * limit;
            //var totalPage = Math.Ceiling(await _cinemaCluster.CountDocumentsAsync(actor => true) / (decimal)limit);
            //return await _cinemaCluster.Find(actor => true).Skip(skip).Limit(limit).ToListAsync();

            BsonDocument limitDoc = new BsonDocument
            {
                {"$limit",limit}
            };
            BsonDocument skipDoc = new BsonDocument
            {
                {"$skip",skip}
            };

            BsonDocument[] pipeline = new BsonDocument[] { skipDoc, limitDoc, Lookup.cinemaclusters_lookup_cinemaimages, Lookup.cinemaclusters_lookup_fareimages, Lookup.cinemaclusters_lookup_cinemas };

            return await _cinemaCluster.Aggregate<CinemaClusters>(pipeline).ToListAsync();
        }
        public async Task<CinemaClusters> GetById(string id)
        {
            return await _cinemaCluster.Find(cinema => cinema.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CinemaClusters>> GetByName(string nameSearch, int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _cinemaCluster.Find(cinema => cinema.CinemaClusterName.Contains(nameSearch) && cinema.IsDeleted == false).Skip(skip).Limit(limit).ToListAsync();
        }
    }
}
