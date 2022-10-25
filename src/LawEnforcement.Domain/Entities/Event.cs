using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawEnforcement.Domain.Entities
{
    public record Event
    {
        public int Id { get; init; }
        public Guid CrimeEventId { get; init; }
    }
}