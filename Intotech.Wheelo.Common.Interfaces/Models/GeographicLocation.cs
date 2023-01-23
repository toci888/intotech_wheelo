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

        protected string LatValue;
        protected string LonValue;

        public string place_id { get; set; }
        public string lat { get { return LatValue.Replace(",", "."); } set { LatValue = value; } }
        public string lon { get { return LonValue.Replace(",", "."); } set { LonValue = value; } }
        public string display_name { get; set; }
        public Address address { get; set; }
    }
}
