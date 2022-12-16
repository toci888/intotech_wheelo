using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vacollocationsgeolocation
    {
        public int? Idaccount { get; set; }
        public int? Accountidcollocated { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double? Latitudefrom { get; set; }
        public double? Longitudefrom { get; set; }
        public double? Latitudeto { get; set; }
        public double? Longitudeto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public string? Searchid { get; set; }
        public int? Isdriver { get; set; }
    }
}
