using LawEnforcement.Domain.Enums;
using LawEnforcement.Domain.ValueObjects;

namespace LawEnforcement.Domain.Entities
{
    public record LawEnforcementTeam
    {
        public int Id { get; init; }

        public string EnforcementNumber { get; init; }

        public Rank Rank { get; set; }

        public IEnumerable<Event> CrimeEvents { get; set; }
    }
}