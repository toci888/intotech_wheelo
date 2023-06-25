using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountmetadatum : ModelBase
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public int Gender { get; set; }
        public string? Pesel { get; set; }
        public string? Phone { get; set; }
        public int? Idgeographicregion { get; set; }
        public int? Idoccupation { get; set; }
        public bool? Issmoker { get; set; }
        public bool? Iswithanimals { get; set; }
        public string? Metajson { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
        public virtual Geographicregion? IdgeographicregionNavigation { get; set; }
        public virtual Occupation? IdoccupationNavigation { get; set; }
    }
}
