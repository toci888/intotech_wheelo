using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vaccountscollocation
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Suggestedname { get; set; }
        public string Suggestedsurname { get; set; }
        public int? Accountid { get; set; }
        public int? Suggestedaccountid { get; set; }
    }
}
