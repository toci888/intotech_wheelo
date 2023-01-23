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
        public int? Idaccount { get; set; }
        public int? Friendidaccount { get; set; }
        public int? Method { get; set; }
        public double? Latitudefrom { get; set; }
        public double? Longitudefrom { get; set; }
        public double? Latitudeto { get; set; }
        public double? Longitudeto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public string? Searchid { get; set; }
        public int? Driverpassenger { get; set; }
    }
}
