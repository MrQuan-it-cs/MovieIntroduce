using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieIntroduce.Models;

namespace MovieIntroduce.Services
{
    public class ImageServices
    {
        private readonly IMongoCollection<Images> _images;
        public ImageServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _images = database.GetCollection<Images>(mongoDBSettings.Value.ImageCollection);
        }
        public async Task<List<Images>> Get(int page, int limit)
        {
            var skip = (page - 1) * limit;
            return await _images.Find(image => true).Skip(skip).Limit(limit).ToListAsync();
        }
    }
}
