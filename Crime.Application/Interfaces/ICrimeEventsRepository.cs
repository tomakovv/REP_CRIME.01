using Crime.Domain.Entities;

namespace Crime.Application.Interfaces
{
    public interface ICrimeEventsRepository
    {
        Task CreateCrimeEventAsync(CrimeEvent crimeEvent);

        Task<CrimeEvent> GetCrimeEventAsync(string id);

        Task<IEnumerable<CrimeEvent>> GetCrimeEventsAsync();
    }
}