using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vaccountscollocationsworktrip : ModelBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Suggestedname { get; set; }
        public string? Suggestedsurname { get; set; }
        public int? Accountid { get; set; }
        public int? Suggestedaccountid { get; set; }
        public decimal? Distancefrom { get; set; }
        public decimal? Distanceto { get; set; }
        public double? Latitudefrom { get; set; }
        public double? Longitudefrom { get; set; }
        public double? Latitudeto { get; set; }
        public double? Longitudeto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
    }
}
