using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models
{
    public class TripDto : Trip
    {
        public List<int> AccountIds { get; set; }
    }
}
