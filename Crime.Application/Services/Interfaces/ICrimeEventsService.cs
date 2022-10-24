using REP_CRIME._01.Common.Dto;
using System;
using System.Linq;

namespace Crime.Application.Services.Interfaces
{
    public interface ICrimeEventsService
    {
        Task CreateNewCrimeEventAsync(CreateCrimeEventDto newCrimeEventDto);

        Task<IEnumerable<CrimeEventDto>> GetAllCrimeEventsAsync();
        Task<CrimeEventDto> GetCrimeEventAsync(string objectId);
    }
}