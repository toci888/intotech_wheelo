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
        public string StartLocationTime { get; set; }
        public string EndLocationTime { get; set; }
        public double AcceptableDistance { get; set; }
        public int AccountId { get; set; }
    }
}
