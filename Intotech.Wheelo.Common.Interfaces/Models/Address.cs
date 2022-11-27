using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class Address
    {
        public string name { get; set; }
        public string house_number { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}, {3}", city, road, house_number, postcode);

        }
    }
}
