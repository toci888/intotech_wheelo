using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelMappers.ModelToDtoMaps
{
    public class VCollocationsGeoLocationModelDto
    {
        public int? IdAccount { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double? Latitudefrom { get; set; }
        public double? Longitudefrom { get; set; }
        public double? Latitudeto { get; set; }
        public double? Longitudeto { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public string? Searchid { get; set; }
    }
}
