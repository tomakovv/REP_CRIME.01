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
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.DatabaseName);
        }

        private readonly IMongoDatabase _db;

        public IMongoCollection<CrimeEvent> Crimes => _db.GetCollection<CrimeEvent>("CrimeEvents");
    }
}