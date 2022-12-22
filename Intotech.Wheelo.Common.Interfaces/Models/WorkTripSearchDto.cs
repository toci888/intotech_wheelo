using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class WorkTripSearchDto
    {
        public GeographicLocation startLocation { get; set; }
        public GeographicLocation endLocation { get; set; }
        public string startLocationTime { get; set; }
        public string endLocationTime { get; set; }
    }
}
