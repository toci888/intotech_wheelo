using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Usersworktime
    {
        public int Id { get; set; }
        public int Idusers { get; set; }
        public string Workstarthour { get; set; }
        public string Workendhour { get; set; }

        public virtual User IdusersNavigation { get; set; }
    }
}
