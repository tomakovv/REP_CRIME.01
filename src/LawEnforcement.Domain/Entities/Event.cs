namespace LawEnforcement.Domain.Entities
{
    public record Event
    {
        public int Id { get; init; }
        public Guid CrimeEventId { get; init; }

        public int LawEnforcementTeamId { get; set; }
    }
}