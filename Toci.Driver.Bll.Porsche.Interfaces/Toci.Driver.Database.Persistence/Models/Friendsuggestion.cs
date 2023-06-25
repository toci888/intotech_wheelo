using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Friendsuggestion : ModelBase
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idsuggested { get; set; }
        public int Idsuggestedfriend { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
        public virtual Account IdsuggestedNavigation { get; set; } = null!;
        public virtual Account IdsuggestedfriendNavigation { get; set; } = null!;
    }
}
