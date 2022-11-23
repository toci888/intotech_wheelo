using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountmetadatum
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public bool? Issmoker { get; set; }
        public bool? Iswithanimals { get; set; }
        public string? Metajson { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
    }
}
