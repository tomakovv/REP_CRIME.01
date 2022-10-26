namespace REP_CRIME._01.Web.Models
{
    public class CrimeEventViewModel
    {
        public DateTime Date { get; init; }
        public Guid EventId { get; init; }
        public string Type { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
        public string Status { get; init; }
        public string ReporterEmail { get; init; }
    }
}