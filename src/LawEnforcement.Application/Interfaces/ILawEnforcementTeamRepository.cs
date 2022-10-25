using LawEnforcement.Domain.Entities;

namespace LawEnforcement.Application.Interfaces
{
    public interface ILawEnforcementTeamRepository
    {
        Task<LawEnforcementTeam> AddCrimeEventToLawEnforcementTeamAsync(LawEnforcementTeam lawEnforcementTeam, Guid crimeEventId);

        Task AddNewLawEnforcementTeamAsync(LawEnforcementTeam lawEnforcementTeam);

        Task<IEnumerable<LawEnforcementTeam>> GetLawEnforcementTeamsAsync();
    }
}