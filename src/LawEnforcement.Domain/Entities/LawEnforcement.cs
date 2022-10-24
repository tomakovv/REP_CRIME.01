using LawEnforcement.Domain.Enums;
using LawEnforcement.Domain.ValueObjects;

namespace LawEnforcement.Domain.Entities
{
    public record LawEnforcement
    {
        public int Id { get; init; }

        public EnforcementNumber EnforcementNumber { get; init; }

        public Rank Rank { get; set; }

        public IEnumerable<Guid> CrimeEvents { get; set; }
    }
}