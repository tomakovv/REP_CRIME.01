using Crime.Domain.Entities.Enums;
using Crime.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net.Mail;

namespace Crime.Domain.Entities
{
    public record CrimeEvent
    {
        [BsonId]
        public ObjectId InternalId { get; init; }
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public MurderEventType Type { get; init; }
        public string Description { get; init; }
        public Location Location { get; init; }
        public MailAddress ReporterEmail { get; init; }
        public CrimeStatus Status { get; init; }
        public int LawEnforcementId { get; init; }

        public CrimeEvent(ObjectId internalId, int id, DateTime date, MurderEventType type, string description, Location location, MailAddress reporterEmail, CrimeStatus status, int lawEnforcementId)
        {
            InternalId = internalId;
            Id = id;
            Date = date;
            Type = type;
            Description = description;
            Location = location;
            ReporterEmail = reporterEmail;
            Status = status;
            LawEnforcementId = lawEnforcementId;
        }
    }
}