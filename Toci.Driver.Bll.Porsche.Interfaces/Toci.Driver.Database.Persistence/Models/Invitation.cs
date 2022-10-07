using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Invitation
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Idinvited { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual User IdinvitedNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
