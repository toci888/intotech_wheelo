using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Statsprovider
    {
        public DateOnly? Tripdate { get; set; }
        public long? Countcars { get; set; }
        public long? Countpeople { get; set; }
    }
}
