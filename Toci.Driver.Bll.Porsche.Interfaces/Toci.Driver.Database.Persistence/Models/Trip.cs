using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Tripparticipants = new HashSet<Tripparticipant>();
        }

        public int Id { get; set; }
        public int? Idinitiatoraccount { get; set; }
        public int? Idworktrip { get; set; }
        public DateOnly? Tripdate { get; set; }
        public bool? Iscurrent { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public string? Summary { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Leftseats { get; set; }

        public virtual Account? IdinitiatoraccountNavigation { get; set; }
        public virtual Worktrip? IdworktripNavigation { get; set; }
        public virtual ICollection<Tripparticipant> Tripparticipants { get; set; }
    }
}
