using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Geographicregion
    {
        public Geographicregion()
        {
            InverseIdparentNavigation = new HashSet<Geographicregion>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? Idparent { get; set; }
        public int? Idshit { get; set; }
        public string Name { get; set; }

        public virtual Geographicregion IdparentNavigation { get; set; }
        public virtual ICollection<Geographicregion> InverseIdparentNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
