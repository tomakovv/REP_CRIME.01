namespace LawEnforcement.Application.Interfaces
{
    public interface ILawEnforcementTeamService
    {
        Task AssignCrimeEventToEnforcementTeamAsync(Guid crimeId);
    }
}