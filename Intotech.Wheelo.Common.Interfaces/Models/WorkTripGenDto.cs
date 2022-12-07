using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class WorkTripGenDto
    {
        public GeographicLocation StartLocation { get; set; }
        public GeographicLocation EndLocation { get; set; }
        public TimeOnly StartLocationTime { get; set; }
        public TimeOnly EndLocationTime { get; set; }
        public double AcceptableDistance { get; set; }
        public int AccountId { get; set; }
    }
}
