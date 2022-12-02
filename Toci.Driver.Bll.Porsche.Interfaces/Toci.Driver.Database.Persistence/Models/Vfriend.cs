using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vfriend
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Friendname { get; set; }
        public string? Friendsurname { get; set; }
        public int? Accountid { get; set; }
        public int? Friendaccountid { get; set; }
        public int? Method { get; set; }
    }
}
