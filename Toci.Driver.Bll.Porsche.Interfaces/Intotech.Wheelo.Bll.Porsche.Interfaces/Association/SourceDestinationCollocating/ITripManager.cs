﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ITripManager
    {
        Trip CreateTrip(Trip trip);
        int AddTripParticipant(int tripId, int accountId);

        // get trip by owner/trip id? 

        List<Vtripsparticipant> GetTripParticipants(DateOnly tripDate, int accountId);
    }
}
