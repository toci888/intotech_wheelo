using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Worktrip
    {
        public Worktrip()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public int Idaccount { get; set; }
        public string Searchid { get; set; } = null!;
        public bool Isuser { get; set; }
        public double Latitudefrom { get; set; }
        public double Longitudefrom { get; set; }
        public double Latitudeto { get; set; }
        public double Longitudeto { get; set; }
        public int? Idgeographiclocationfrom { get; set; }
        public int? Idgeographiclocationto { get; set; }
        public string? Streetfrom { get; set; }
        public string? Streetto { get; set; }
        public string? Cityfrom { get; set; }
        public string? Cityto { get; set; }
        public string? Postcodefrom { get; set; }
        public string? Postcodeto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public double? Acceptabledistance { get; set; }
        public DateTime? Createdat { get; set; }
        public int Driverpassenger { get; set; }

        public virtual Geographicregion? IdgeographiclocationfromNavigation { get; set; }
        public virtual Geographicregion? IdgeographiclocationtoNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
