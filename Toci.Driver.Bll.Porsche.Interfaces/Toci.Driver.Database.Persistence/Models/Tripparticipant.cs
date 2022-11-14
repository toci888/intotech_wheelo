using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Tripparticipant
    {
        public int Id { get; set; }
        public int? Idtrip { get; set; }
        public int? Idaccount { get; set; }
        public bool? Isoccasion { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
        public virtual Trip? IdtripNavigation { get; set; }
    }
}
