using System.Net.Mail;

namespace REP_CRIME._01.Common.Dto
{
    public record CrimeEventDto(int Id, DateTime Date, string Type, string Description, string Location, string Status);
}