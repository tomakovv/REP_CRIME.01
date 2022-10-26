using Crime.Application.Interfaces;
using Crime.Domain.Entities;
using Crime.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Crime.Persistence.Repositories
{
    public class CrimeEventsRepository : ICrimeEventsRepository
    {
        private readonly ICrimeContext _context;

        public CrimeEventsRepository(ICrimeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CrimeEvent>> GetCrimeEventsAsync() => await _context.Crimes.Find(_ => true).ToListAsync();

        public async Task<CrimeEvent> GetCrimeEventAsync(Guid id)
        {
            FilterDefinition<CrimeEvent> filter = Builders<CrimeEvent>.Filter.Eq(m => m.EventId, id);
            return await _context.Crimes.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateCrimeEventAsync(CrimeEvent crimeEvent) => await _context.Crimes.InsertOneAsync(crimeEvent);

        public async Task UpdateCrimeEventAsync(CrimeEvent crimeEvent) => await _context.Crimes.ReplaceOneAsync(filter: g => g.EventId == crimeEvent.EventId, replacement: crimeEvent);

        public async Task<long> GetNumberOfAllCrimeEventsAsync() => await _context.Crimes.CountDocumentsAsync(new BsonDocument());
    }
}