using LawEnforcement.Application.Interfaces;
using LawEnforcement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcement.Persistence.Repositories
{
    public class LawEnforcementTeamRepository : ILawEnforcementTeamRepository
    {
        private readonly LawEnforcementContext _context;

        public LawEnforcementTeamRepository(LawEnforcementContext lawEnforcementContext)

        {
            _context = lawEnforcementContext;
        }

        public async Task<IEnumerable<LawEnforcementTeam>> GetLawEnforcementTeamsAsync() => await _context.LawEnforcementTeams.ToListAsync();

        public async Task AddNewLawEnforcementTeamAsync(LawEnforcementTeam lawEnforcementTeam)
        {
            await _context.AddAsync(lawEnforcementTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<LawEnforcementTeam> AddCrimeEventToLawEnforcementTeamAsync(LawEnforcementTeam lawEnforcementTeam, Guid crimeEventId)
        {
            lawEnforcementTeam.CrimeEvents.Append(new Event { CrimeEventId = crimeEventId });
            await _context.SaveChangesAsync();
            return lawEnforcementTeam;
        }
    }
}