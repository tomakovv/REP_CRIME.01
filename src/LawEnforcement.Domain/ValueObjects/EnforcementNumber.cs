using System.Text.RegularExpressions;

namespace LawEnforcement.Domain.ValueObjects
{
    public record EnforcementNumber
    {
        public string Number { get; init; }

        private EnforcementNumber(string number)
        {
            Number = number;
        }

        public static EnforcementNumber Create(string number)
        {
            Regex regex = new Regex("^[A-Z]{3,}\\d{2,}$");
            if (regex.IsMatch(number))
                return new EnforcementNumber(number);
            throw new ArgumentException("Invalid Enforcement number");
        }
    }
}