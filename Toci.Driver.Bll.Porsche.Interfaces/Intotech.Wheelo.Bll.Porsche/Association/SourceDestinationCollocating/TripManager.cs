﻿using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class TripManager : ITripManager
    {
        protected ITripLogic TripLogic;
        protected ITripparticipantLogic TripparticipantLogic;
        protected IVTripsParticipantsLogic VTripparticipantLogic;
        protected IAccountsCarsLocationLogic VAccountsCarsLocationLogic;

        public TripManager(ITripLogic tripLogic, ITripparticipantLogic tripparticipantLogic, 
            IVTripsParticipantsLogic vTripparticipantLogic, IAccountsCarsLocationLogic vAccountsCarsLocationLogic)
        {
            TripLogic = tripLogic;
            TripparticipantLogic = tripparticipantLogic;
            VTripparticipantLogic = vTripparticipantLogic;
            VAccountsCarsLocationLogic = vAccountsCarsLocationLogic;
        }

        public int AddTripParticipant(int tripId, int accountId)
        {
            return TripparticipantLogic.Insert(new Tripparticipant() { Idtrip = tripId, Idaccount = accountId }).Id;
        }

        public virtual Trip CreateTrip(Trip trip, List<int> accountIds)
        {
            trip.Iscurrent = true;

            Accountscarslocation accountscarslocation = VAccountsCarsLocationLogic.Select(m => m.Accountid == trip.Idinitiatoraccount).First();

            //trip.Summary
            trip.Leftseats = accountscarslocation.Availableseats - accountIds.Count();

            Trip newTrip = TripLogic.Insert(trip);

            foreach (int accountId in accountIds)
            {
                TripparticipantLogic.Insert(new Tripparticipant() { Idaccount = accountId, Idtrip = newTrip.Id, Isoccasion = false });
            }

            return newTrip;
        }

        public virtual List<Trip> GetAllTrips(int accountId)
        {
            List<int> tripsIds = TripparticipantLogic.Select(m => m.Idaccount == accountId).Select(m => m.Idtrip.Value).ToList();

            return TripLogic.Select(m => tripsIds.Contains(m.Id)).ToList();
        }

        public virtual List<Trip> GetInitiatorTrips(int inititatorAccountId)
        {
            return TripLogic.Select(m => m.Idinitiatoraccount == inititatorAccountId).ToList(); 
        }

        public virtual Trip GetTrip(int tripId)
        {
            return TripLogic.Select(m => m.Id == tripId).First();
        }

        public virtual List<Vtripsparticipant> GetTripParticipants(int accountId)
        {
            int tripId = VTripparticipantLogic.Select(m => m.Accountid.Value == accountId && m.Iscurrent.Value).First().Tripid.Value;

            return VTripparticipantLogic.Select(m => m.Tripid == tripId).ToList();
        }

        public virtual bool SetTripNotCurrent(int tripId, int inititatorAccountId)
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId && m.Idinitiatoraccount == inititatorAccountId).First();

            trip.Iscurrent = false;

            return TripLogic.Update(trip).Id > 0;
        }
    }
}