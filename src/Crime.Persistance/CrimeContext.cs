using Crime.Domain.Entities;
using Crime.Persistence.Interfaces;
using Crime.Persistence.MongoConfiguration;
using MongoDB.Driver;

namespace Crime.Persistence
{
    public class CrimeContext : ICrimeContext
    {
        public CrimeContext(MongoDBSettings config)
        {
            //mongodb://mongouser:mongopassword@mongo-service:27017/
            //mongodb://root:example@mongo:27017/
            var client = new MongoClient("mongodb://root:example@mongo:27017/");
            _db = client.GetDatabase(config.DatabaseName);
        }

        private readonly IMongoDatabase _db;

        public IMongoCollection<CrimeEvent> Crimes => _db.GetCollection<CrimeEvent>("CrimeEvents");
    }
}