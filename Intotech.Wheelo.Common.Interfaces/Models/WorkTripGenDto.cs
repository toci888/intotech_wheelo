using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class WorkTripGenDto : WorkTripSearchDto
    {
        
        public double AcceptableDistance { get; set; }
        public int Idaccount { get; set; }
        public int IsDriver { get; set; }
    }
}
