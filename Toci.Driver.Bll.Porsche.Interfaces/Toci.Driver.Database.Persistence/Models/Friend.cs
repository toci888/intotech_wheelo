using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idfriend { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
        public virtual Account IdfriendNavigation { get; set; } = null!;
    }
}
