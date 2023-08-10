using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vfriendsuggestion : ModelBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Suggestedname { get; set; }
        public string? Suggestedsurname { get; set; }
        public int? Accountid { get; set; }
        public int? Suggestedaccountid { get; set; }
        public string? Suggestedfriendname { get; set; }
        public string? Suggestedfriendsurname { get; set; }
        public int? Suggestedfriendid { get; set; }
    }
}
