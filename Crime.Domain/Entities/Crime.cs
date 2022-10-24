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
        public ObjectId InternalId { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MurderEventType Type { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public MailAddress ReporterEmail { get; set; }
        public CrimeStatus Status { get; set; }
        public int LawEnforcementId { get; set; }
    }
}