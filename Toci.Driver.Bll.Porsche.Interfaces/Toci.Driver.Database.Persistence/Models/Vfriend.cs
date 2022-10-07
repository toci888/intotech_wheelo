using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vfriend
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Suggestedname { get; set; }
        public string Suggestedsurname { get; set; }
        public int? Userid { get; set; }
        public int? Suggesteduserid { get; set; }
    }
}
