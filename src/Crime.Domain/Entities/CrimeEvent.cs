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
        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public MurderEventType Type { get; init; }
        public string Description { get; init; }
        public Location Location { get; init; }
        public MailAddress ReporterEmail { get; init; }
        public CrimeStatus Status { get; init; }
        public int LawEnforcementId { get; init; }
    }
}