using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime.Domain.Entities
{
    public record Crime
    {
        public ObjectId MyProperty { get; set; }
    }
}