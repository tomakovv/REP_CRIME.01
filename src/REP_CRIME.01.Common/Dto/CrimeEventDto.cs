namespace REP_CRIME._01.Common.Dto
{
    public record CrimeEventDto(DateTime Date, string Type, string Description, string Location, string Status, string ReporterEmail)
    {
    }
}