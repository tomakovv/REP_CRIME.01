namespace REP_CRIME._01.Common.Dto
{
    public record CreateCrimeEventDto(int Type, string Description, string City, string Street, string ZipCode, string ReporterEmail);
}