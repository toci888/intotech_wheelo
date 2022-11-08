using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Worktrip
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public double? Latitudefrom { get; set; }
        public double? Longitudefrom { get; set; }
        public double? Latitudeto { get; set; }
        public double? Longitudeto { get; set; }
        public string? Streetfrom { get; set; }
        public string? Streetto { get; set; }
        public string? Cityfrom { get; set; }
        public string? Cityto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public double? Acceptabledistance { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
    }
}
