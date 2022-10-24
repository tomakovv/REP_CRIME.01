using System.Text.RegularExpressions;

namespace Crime.Domain.ValueObjects
{
    public record Location
    {
        public string City { get; init; }
        public string Street { get; init; }
        public string ZipCode { get; init; }

        private Location(string city, string street, string zipCode)
        {
            Street = street;
            ZipCode = zipCode;
            City = city;
        }

        public static Location Create(string city, string street, string zipCode)
        {
            Regex regex = new Regex("^\\d{2}-\\d{3}$");
            if (regex.IsMatch(zipCode))
                return new Location(city, street, zipCode);
            throw new ArgumentException("Invalid zip code");
        }

        public override string? ToString() => $"{Street} {City} {ZipCode}";
    }
}