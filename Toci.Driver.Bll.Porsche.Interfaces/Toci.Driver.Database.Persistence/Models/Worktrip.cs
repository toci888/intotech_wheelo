using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Worktrip
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public decimal? Latitudefrom { get; set; }
        public decimal? Longitudefrom { get; set; }
        public decimal? Latitudeto { get; set; }
        public decimal? Longitudeto { get; set; }
        public string? Streetfrom { get; set; }
        public string? Streetto { get; set; }
        public string? Cityfrom { get; set; }
        public string? Cityto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public decimal? Acceptabledistance { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
    }
}
