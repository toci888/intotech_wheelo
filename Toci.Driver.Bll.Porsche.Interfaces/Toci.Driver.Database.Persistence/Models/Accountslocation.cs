using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountslocation
    {
        public int Id { get; set; }
        public int Idaccounts { get; set; }
        public string Coordinatesfrom { get; set; }
        public string Coordinatesto { get; set; }
        public string Streetfrom { get; set; }
        public string Streetto { get; set; }
        public string Cityfrom { get; set; }
        public string Cityto { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountsNavigation { get; set; }
    }
}
