using System;
using System.Collections.Generic;

#nullable disable

namespace Wheelo.Nfs.Database.Persistence.Models
{
    public partial class Vinvitation
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Suggestedname { get; set; }
        public string Suggestedsurname { get; set; }
        public int? Userid { get; set; }
        public int? Suggesteduserid { get; set; }
    }
}
