using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
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

        public ReturnedResponse<int> AddTripParticipant(int tripId, int accountId)
        {
            return new ReturnedResponse<int>(TripparticipantLogic.Insert(new Tripparticipant() { Idtrip = tripId, Idaccount = accountId }).Id, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Trip> CreateTrip(Trip trip, List<int> accountIds)
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

            return new ReturnedResponse<Trip>(newTrip, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Trip>> GetAllTrips(int accountId)
        {
            List<int> tripsIds = TripparticipantLogic.Select(m => m.Idaccount == accountId).Select(m => m.Idtrip.Value).ToList();

            return new ReturnedResponse<List<Trip>>(TripLogic.Select(m => tripsIds.Contains(m.Id)).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Trip>> GetInitiatorTrips(int inititatorAccountId)
        {
            return new ReturnedResponse<List<Trip>>(TripLogic.Select(m => m.Idinitiatoraccount == inititatorAccountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success); 
        }

        public virtual ReturnedResponse<Trip> GetTrip(int tripId) //zmienione 1.12.22
        {
            return new ReturnedResponse<Trip>(TripLogic.Select(m => m.Id == tripId).First(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId)
        {
            int tripId = VTripparticipantLogic.Select(m => m.Accountid.Value == accountId && m.Iscurrent.Value).First().Tripid.Value;

            return new ReturnedResponse<List<Vtripsparticipant>>(VTripparticipantLogic.Select(m => m.Tripid == tripId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> SetTripNotCurrent(int tripId, int inititatorAccountId) //zmienione 1.12.22
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId && m.Idinitiatoraccount == inititatorAccountId).First();

            trip.Iscurrent = false;

            return new ReturnedResponse<bool>(TripLogic.Update(trip).Id > 0, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success); ; ; ;
        }
    }
}