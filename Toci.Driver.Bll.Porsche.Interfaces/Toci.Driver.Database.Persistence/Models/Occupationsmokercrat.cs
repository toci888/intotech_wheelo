using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Occupationsmokercrat
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public int? Idoccupation { get; set; }
        public bool? Issmoker { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
        public virtual Occupation? IdoccupationNavigation { get; set; }
    }
}
