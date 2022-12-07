using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.TripCollocation
{
    public class TripGenCollocationDto
    {
        public Vworktripgengeolocation SourceAccount { get; set; }

        public List<Vaworktripgengeolocation> AccountsCollocated { get; set; } //Vaccountscollocationsworktrip
    }
}
