using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Worktrip
    {
        public int Id { get; set; }
        public int? Iduser { get; set; }
        public decimal? Fromlongitude { get; set; }
        public decimal? Fromlatitude { get; set; }
        public string Fromstreet { get; set; }
        public decimal? Tolongitude { get; set; }
        public decimal? Tolatitude { get; set; }
        public string Tostreet { get; set; }
        public TimeSpan? Fromhour { get; set; }
        public TimeSpan? Tohour { get; set; }
        public decimal? Acceptabledistance { get; set; }

        public virtual User IduserNavigation { get; set; }
    }
}
