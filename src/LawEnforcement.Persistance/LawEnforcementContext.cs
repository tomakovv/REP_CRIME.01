using LawEnforcement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcement.Persistence
{
    public class LawEnforcementContext : DbContext
    {
        public DbSet<LawEnforcementTeam> LawEnforcementTeams { get; set; }

        public LawEnforcementContext(DbContextOptions options) : base(options)
        {
        }
    }
}