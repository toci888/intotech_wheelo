using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vfriendsuggestion
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Suggestedname { get; set; }
        public string Suggestedsurname { get; set; }
        public int? Accountid { get; set; }
        public int? Suggestedaccountid { get; set; }
    }
}
