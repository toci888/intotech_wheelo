using System;
using System.Collections.Generic;

#nullable disable

namespace Wheelo.Nfs.Database.Persistence.Models
{
    public partial class Friendsuggestion
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Idsuggested { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual User IdsuggestedNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
