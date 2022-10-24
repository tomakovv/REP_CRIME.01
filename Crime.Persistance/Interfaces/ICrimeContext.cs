using Crime.Domain.Entities;
using MongoDB.Driver;

namespace Crime.Persistence.Interfaces
{
    public interface ICrimeContext
    {
        IMongoCollection<CrimeEvent> Crimes { get; }
    }
}