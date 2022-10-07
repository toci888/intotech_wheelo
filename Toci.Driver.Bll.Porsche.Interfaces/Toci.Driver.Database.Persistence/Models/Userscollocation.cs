using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Userscollocation
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Idcollocated { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual User IdcollocatedNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
