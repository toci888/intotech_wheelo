using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Friendsuggestion
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idsuggested { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
        public virtual Account IdsuggestedNavigation { get; set; } = null!;
    }
}
