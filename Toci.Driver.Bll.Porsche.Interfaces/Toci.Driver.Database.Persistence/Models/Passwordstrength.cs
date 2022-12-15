using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Passwordstrength
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Level { get; set; }
    }
}
