using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountsworktime
    {
        public int Id { get; set; }
        public int Idaccounts { get; set; }
        public string Workstarthour { get; set; }
        public string Workendhour { get; set; }

        public virtual Account IdaccountsNavigation { get; set; }
    }
}
