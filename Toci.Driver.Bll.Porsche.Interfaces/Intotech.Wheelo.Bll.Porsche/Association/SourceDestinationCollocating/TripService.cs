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
using Intotech.Common;
using Intotech.Wheelo.Bll.Models.Trip;
using Intotech.Wheelo.Bll.Persistence;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class TripService : ITripService
    {
        protected ITripLogic TripLogic;
        protected ITripparticipantLogic TripparticipantLogic;
        protected IVTripsParticipantsLogic VTripparticipantLogic;
        protected IAccountsCarsLocationLogic VAccountsCarsLocationLogic;

        public TripService(ITripLogic tripLogic, ITripparticipantLogic tripparticipantLogic, 
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

        public virtual ReturnedResponse<bool> ConfirmTripParticipation(TripParticipationConfirmationDto tripAccountConfirm)
        {
            Trip trip = TripLogic.Select(m => m.Idinitiatoraccount == tripAccountConfirm.InitiatorAccountId && m.Iscurrent == true).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }

            Tripparticipant tripParticipant = TripparticipantLogic
                .Select(m => m.Idtrip == trip.Id && m.Idaccount == tripAccountConfirm.PassengerAccountId)
                .FirstOrDefault();

            if (tripParticipant == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }

            tripParticipant.Isconfirmed = true;

            TripparticipantLogic.Update(tripParticipant);

            return new ReturnedResponse<bool>(true, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Trip> CreateTrip(TripDto trip)
        {
            trip.Iscurrent = true;

            Accountscarslocation accountscarslocation = VAccountsCarsLocationLogic.Select(m => m.Idaccount == trip.Idinitiatoraccount).FirstOrDefault();

            if (accountscarslocation == null)
            {
                return new ReturnedResponse<Trip>(null, I18nTranslation.Translation(I18nTags.WrongData), false, ErrorCodes.DataIntegrityViolated);
            }

            //trip.Summary
            trip.Leftseats = accountscarslocation.Availableseats - trip.AccountIds.Count();

            Trip dbTrip = DtoModelMapper.Map<Trip, TripDto>(trip);

            Trip newTrip = TripLogic.Insert(dbTrip);

            foreach (int accountId in trip.AccountIds)
            {
                TripparticipantLogic.Insert(new Tripparticipant() { Idaccount = accountId, Idtrip = newTrip.Id, Isoccasion = false, Isconfirmed = false });
            }

            return new ReturnedResponse<Trip>(newTrip, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Trip>> GetAllTrips(int accountId)
        {
            List<int> tripsIds = TripparticipantLogic.Select(m => m.Idaccount == accountId).Select(m => m.Idtrip).ToList();

            return new ReturnedResponse<List<Trip>>(TripLogic.Select(m => tripsIds.Contains(m.Id)).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Trip>> GetInitiatorTrips(int inititatorAccountId)
        {
            return new ReturnedResponse<List<Trip>>(TripLogic.Select(m => m.Idinitiatoraccount == inititatorAccountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success); 
        }

        public virtual ReturnedResponse<TripWithParticipantsDto> GetTrip(int tripId) //zmienione 1.12.22
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<TripWithParticipantsDto>(null, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }

            TripWithParticipantsDto tripWithParticipants = DtoModelMapper.Map<TripWithParticipantsDto, Trip>(trip);

            tripWithParticipants.Participants = VTripparticipantLogic.Select(m => m.Tripid == tripId).ToList();

            return new ReturnedResponse<TripWithParticipantsDto>(tripWithParticipants, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId)
        {
            int tripId = VTripparticipantLogic.Select(m => m.Accountid.Value == accountId && m.Iscurrent.Value).First().Tripid.Value;

            return new ReturnedResponse<List<Vtripsparticipant>>(VTripparticipantLogic.Select(m => m.Tripid == tripId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> SetTripNotCurrent(int tripId, int inititatorAccountId) //zmienione 1.12.22
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId && m.Idinitiatoraccount == inititatorAccountId).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            trip.Iscurrent = false;

            return new ReturnedResponse<bool>(TripLogic.Update(trip).Id > 0, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}