using Crime.Domain.Entities;

namespace Crime.Application.Interfaces
{
    public interface ICrimeEventsRepository
    {
        Task CreateCrimeEventAsync(CrimeEvent crimeEvent);

        Task<CrimeEvent> GetCrimeEventAsync(Guid crimeId);

        Task<IEnumerable<CrimeEvent>> GetCrimeEventsAsync();

        Task<long> GetNumberOfAllCrimeEventsAsync();

        Task UpdateCrimeEventAsync(CrimeEvent crimeEvent);
    }
}