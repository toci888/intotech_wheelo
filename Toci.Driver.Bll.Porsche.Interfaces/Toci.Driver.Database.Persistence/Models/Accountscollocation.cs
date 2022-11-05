using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountscollocation
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idcollocated { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual Account IdcollocatedNavigation { get; set; }
    }
}
