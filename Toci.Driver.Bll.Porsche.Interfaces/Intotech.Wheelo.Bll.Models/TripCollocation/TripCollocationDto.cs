﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.TripCollocation
{
    public class TripCollocationDto // DEPRECATED
    {
        public List<Vacollocationsgeolocation> AccountsCollocated { get; set; } //Vaccountscollocationsworktrip

        public Vcollocationsgeolocation SourceAccount { get; set; }
    }
}
