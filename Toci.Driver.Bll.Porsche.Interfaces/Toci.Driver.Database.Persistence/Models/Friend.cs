using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Friend : ModelBase
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idfriend { get; set; }
        public int? Method { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
        public virtual Account IdfriendNavigation { get; set; } = null!;
    }
}
