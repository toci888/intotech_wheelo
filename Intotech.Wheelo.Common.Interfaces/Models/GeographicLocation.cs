using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class GeographicLocation
    {
        public GeographicLocation()
        {
            address = new Address();
        }

        public string place_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string[] boundingbox { get; set; }
        public string display_name { get; set; }
        public string display_address { get; set; }
        public Address address { get; set; }
    }
}
