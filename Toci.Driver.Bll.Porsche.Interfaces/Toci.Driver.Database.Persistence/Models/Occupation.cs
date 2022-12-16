using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            Accountmetadata = new HashSet<Accountmetadatum>();
            Occupationsmokercrats = new HashSet<Occupationsmokercrat>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Accountmetadatum> Accountmetadata { get; set; }
        public virtual ICollection<Occupationsmokercrat> Occupationsmokercrats { get; set; }
    }
}
