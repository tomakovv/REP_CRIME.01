﻿using Crime.Application.Interfaces;
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

        public async Task<CrimeEvent> GetCrimeEventAsync(string objectId)
        {
            FilterDefinition<CrimeEvent> filter = Builders<CrimeEvent>.Filter.Eq(m => m.InternalId, new ObjectId(objectId));
            return await _context.Crimes.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateCrimeEventAsync(CrimeEvent crimeEvent) => await _context.Crimes.InsertOneAsync(crimeEvent);
    }
}