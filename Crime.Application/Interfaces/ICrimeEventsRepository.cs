using Crime.Domain.Entities;

namespace Crime.Application.Interfaces
{
    public interface ICrimeEventsRepository
    {
        Task<CrimeEvent> GetCrimeEventAsync(int id);

        Task<IEnumerable<CrimeEvent>> GetCrimeEventsAsync();
    }
}