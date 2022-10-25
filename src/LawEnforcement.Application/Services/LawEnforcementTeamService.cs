using LawEnforcement.Application.Interfaces;
using LawEnforcement.Application.LawEnforcement.Messaging.Send;
using REP_CRIME._01.Common.Dto;
using REP_CRIME._01.Common.Exceptions;

namespace LawEnforcement.Application.Services
{
    public class LawEnforcementTeamService : ILawEnforcementTeamService
    {
        private readonly ILawEnforcementTeamRepository _lawEnforcementTeamRepository;
        private readonly ICrimeEventAssignmentResultSender _crimeEventAssignmentResultSender;

        public LawEnforcementTeamService(ILawEnforcementTeamRepository lawEnforcementTeamRepository, ICrimeEventAssignmentResultSender crimeEventAssignmentResultSender)
        {
            _lawEnforcementTeamRepository = lawEnforcementTeamRepository;
            _crimeEventAssignmentResultSender = crimeEventAssignmentResultSender;
        }

        public async Task AssignCrimeEventToEnforcementTeamAsync(Guid crimeId)
        {
            var allTeams = await _lawEnforcementTeamRepository.GetLawEnforcementTeamsAsync();

            var availableTeam = allTeams.OrderBy(t => t.CrimeEvents.Count()).FirstOrDefault();
            if (availableTeam == null)
                throw new ResourceNotFoundException("Law Enforcement team not found");

            await _lawEnforcementTeamRepository.AddCrimeEventToLawEnforcementTeamAsync(availableTeam, crimeId);
            _crimeEventAssignmentResultSender.SendCrimeEventAssignmentResult(new AssignmentResult(availableTeam.Id, crimeId));
        }
    }
}