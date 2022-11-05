using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Worktrip
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public decimal? Fromlongitude { get; set; }
        public decimal? Fromlatitude { get; set; }
        public string Fromstreet { get; set; }
        public decimal? Tolongitude { get; set; }
        public decimal? Tolatitude { get; set; }
        public string Tostreet { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public decimal? Acceptabledistance { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
    }
}
