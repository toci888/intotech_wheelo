using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountmode
    {
        public int Idaccount { get; set; }
        public int Mode { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
    }
}
