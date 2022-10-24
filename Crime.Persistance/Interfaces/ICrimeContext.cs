using Crime.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime.Persistence.Interfaces
{
    public interface ICrimeContext
    {
        IMongoCollection<CrimeEvent> Crimes { get; }
    }
}