using LawEnforcement.Application.Interfaces;

namespace LawEnforcement.Application.Services
{
    public class LawEnforcementTeamService : ILawEnforcementTeamService
    {
        private readonly ILawEnforcementTeamRepository _lawEnforcementTeamRepository;

        public LawEnforcementTeamService(ILawEnforcementTeamRepository lawEnforcementTeamRepository)
        {
            _lawEnforcementTeamRepository = lawEnforcementTeamRepository;
        }

        public async Task AssignCrimeEventToEnforcementTeamAsync(Guid crimeId)
        {
            var allTeams = await _lawEnforcementTeamRepository.GetLawEnforcementTeamsAsync();

            var availableTeam = allTeams.OrderBy(t => t.CrimeEvents.Count()).FirstOrDefault();
            if (availableTeam == null)
                throw new Exception("Law Enforcement team not found");

            await _lawEnforcementTeamRepository.AddCrimeEventToLawEnforcementTeamAsync(availableTeam, crimeId);
        }
    }
}