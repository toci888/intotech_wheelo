﻿using Intotech.Common.Bll.ComplexResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ITripManager
    {
        ReturnedResponse<Trip> CreateTrip(Trip trip, List<int> accountIds);
        int AddTripParticipant(int tripId, int accountId);

        bool SetTripNotCurrent(int tripId, int inititatorAccountId);

        ReturnedResponse<List<Trip>> GetAllTrips(int accountId);

        Trip GetTrip(int tripId);

        ReturnedResponse<List<Trip>> GetInitiatorTrips(int inititatorAccountId);

        ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId);
    }
}
