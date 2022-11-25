using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Geographicregion
    {
        public Geographicregion()
        {
            Accounts = new HashSet<Account>();
            InverseIdparentNavigation = new HashSet<Geographicregion>();
            Statisticstrips = new HashSet<Statisticstrip>();
            WorktripIdgeographiclocationfromNavigations = new HashSet<Worktrip>();
            WorktripIdgeographiclocationtoNavigations = new HashSet<Worktrip>();
        }

        public int Id { get; set; }
        public int? Idparent { get; set; }
        public int? Idshit { get; set; }
        public string? Name { get; set; }
        public int? Nestlevel { get; set; }

        public virtual Geographicregion? IdparentNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Geographicregion> InverseIdparentNavigation { get; set; }
        public virtual ICollection<Statisticstrip> Statisticstrips { get; set; }
        public virtual ICollection<Worktrip> WorktripIdgeographiclocationfromNavigations { get; set; }
        public virtual ICollection<Worktrip> WorktripIdgeographiclocationtoNavigations { get; set; }
    }
}
