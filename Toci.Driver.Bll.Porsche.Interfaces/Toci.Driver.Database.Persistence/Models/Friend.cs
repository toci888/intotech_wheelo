using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Idfriend { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual User IdfriendNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
