using Crime.Domain.Entities;
using Crime.Persistence.Interfaces;
using Crime.Persistence.MongoConfiguration;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Crime.Persistence
{
    public class CrimeContext : ICrimeContext
    {
        private readonly IConfiguration configuration;

        public CrimeContext(MongoDBSettings config, IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoConnectionString"]);
            _db = client.GetDatabase(config.DatabaseName);
            this.configuration = configuration;
        }

        private readonly IMongoDatabase _db;

        public IMongoCollection<CrimeEvent> Crimes => _db.GetCollection<CrimeEvent>("CrimeEvents");
    }
}