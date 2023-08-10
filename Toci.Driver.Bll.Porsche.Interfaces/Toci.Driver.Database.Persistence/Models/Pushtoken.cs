using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Pushtoken : ModelBase
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public string Token { get; set; } = null!;
        public DateTime Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
    }
}
