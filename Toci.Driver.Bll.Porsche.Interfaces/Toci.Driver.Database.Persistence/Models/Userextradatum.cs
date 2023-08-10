using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Userextradatum : ModelBase
    {
        public int Id { get; set; }
        public int? Idaccount { get; set; }
        public string? Token { get; set; }
        public string? Method { get; set; }
        public string? Tokendatajson { get; set; }
        public int Origin { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account? IdaccountNavigation { get; set; }
    }
}
