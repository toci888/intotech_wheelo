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
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Models.TripEx;
using Intotech.Common.Bll;
using Intotech.Common.Interfaces;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class TripService : ServiceBaseEx, ITripService
    {
        protected ITripLogic TripLogic;
        protected ITripparticipantLogic TripparticipantLogic;
        protected IVtripsparticipantLogic VTripparticipantLogic;
        protected IAccountscarslocationLogic VAccountsCarsLocationLogic;
        protected IAccountLogic AccountLogic;

        public TripService(
            ITripLogic tripLogic,
            ITripparticipantLogic tripparticipantLogic,
            IVtripsparticipantLogic vTripparticipantLogic,
            IAccountscarslocationLogic vAccountsCarsLocationLogic,
            IAccountLogic accountLogic, 
            ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            TripLogic = tripLogic;
            TripparticipantLogic = tripparticipantLogic;
            VTripparticipantLogic = vTripparticipantLogic;
            VAccountsCarsLocationLogic = vAccountsCarsLocationLogic;
            AccountLogic = accountLogic;
        }

        public ReturnedResponse<int> AddTripParticipant(int tripId, int accountId)
        {
            return new ReturnedResponse<int>(TripparticipantLogic.Insert(new Tripparticipant() { Idtrip = tripId, Idaccount = accountId }).Id, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> ConfirmTripParticipation(TripParticipationConfirmationDto entityDto)
        {
            Trip trip = TripLogic.Select(m => m.Idinitiatoraccount == entityDto.InitiatorAccountId && m.Iscurrent == true).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translate(entityDto.Language,I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }

            Tripparticipant tripParticipant = TripparticipantLogic
                .Select(m => m.Idtrip == trip.Id && m.Idaccount == entityDto.PassengerAccountId)
                .FirstOrDefault();

            if (tripParticipant == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translate(entityDto.Language, I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }

            tripParticipant.Isconfirmed = true;

            TripparticipantLogic.Update(tripParticipant);

            return new ReturnedResponse<bool>(true, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<TripWithParticipantsDto> CreateTrip(TripDto entityDto)
        {
            entityDto.Iscurrent = true;

            Accountscarslocation accountscarslocation = VAccountsCarsLocationLogic.Select(m => m.Idaccount == entityDto.Idinitiatoraccount).FirstOrDefault();

            if (accountscarslocation == null)
            {
                return new ReturnedResponse<TripWithParticipantsDto>(null, I18nTranslation.Translate(entityDto.Language, I18nTags.WrongData), false, ErrorCodes.DataIntegrityViolated);
            }

            //trip.Summary
            entityDto.Leftseats = accountscarslocation.Availableseats - entityDto.AccountIds.Count();

            Trip dbTrip = DtoModelMapper.Map<Trip, TripDto>(entityDto);

            Trip newTrip = TripLogic.Insert(dbTrip);

            foreach (int accountId in entityDto.AccountIds)
            {
                TripparticipantLogic.Insert(new Tripparticipant() { Idaccount = accountId, Idtrip = newTrip.Id, Isoccasion = false, Isconfirmed = false });
            }

            TripWithParticipantsDto result = GetTripsWithInitiator(new List<Trip>() { newTrip }).First();

            return new ReturnedResponse<TripWithParticipantsDto>(result, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<TripWithParticipantsDto>> GetAllTrips(int accountId) //#TODO: REQUIREDTO
        {
            List<int> tripsIds = TripparticipantLogic.Select(m => m.Idaccount == accountId).Select(m => m.Idtrip).ToList();
            
            List<Trip> trips = TripLogic.Select(m => tripsIds.Contains(m.Id)).ToList();

            return new ReturnedResponse<List<TripWithParticipantsDto>>(GetTripsWithInitiator(trips), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<TripWithParticipantsDto>> GetInitiatorTrips(int inititatorAccountId)
        {
            return new ReturnedResponse<List<TripWithParticipantsDto>>(GetTripsWithInitiator(TripLogic.Select(m => m.Idinitiatoraccount == inititatorAccountId).ToList()), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success); 
        }

        public virtual ReturnedResponse<TripWithParticipantsDto> GetTrip(int tripId) //zmienione 1.12.22
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<TripWithParticipantsDto>(null, I18nTranslationDep.Translation(I18nTags.NoData), false, ErrorCodes.DataIntegrityViolated);
            }
            
            return new ReturnedResponse<TripWithParticipantsDto>(GetTripsWithInitiator(new List<Trip>() { trip }).First(), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId)
        {
            int tripId = VTripparticipantLogic.Select(m => m.Accountid.Value == accountId && m.Iscurrent.Value).First().Tripid.Value;

            return new ReturnedResponse<List<Vtripsparticipant>>(VTripparticipantLogic.Select(m => m.Tripid == tripId).ToList(), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> SetTripNotCurrent(int tripId, int inititatorAccountId) //zmienione 1.12.22
        {
            Trip trip = TripLogic.Select(m => m.Id == tripId && m.Idinitiatoraccount == inititatorAccountId).FirstOrDefault();

            if (trip == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslationDep.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            trip.Iscurrent = false;

            return new ReturnedResponse<bool>(TripLogic.Update(trip).Id > 0, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        protected virtual List<TripWithParticipantsDto> GetTripsWithInitiator(List<Trip> trips)
        {
            List<TripWithParticipantsDto> tripsWithInititator = new List<TripWithParticipantsDto>();

            Dictionary<int, Account> accountMap = new Dictionary<int, Account>();

            foreach (Trip trip in trips)
            {
                TripWithParticipantsDto element = DtoModelMapper.Map<TripWithParticipantsDto, Trip>(trip);

                element.Participants = VTripparticipantLogic.Select(m => m.Tripid == trip.Id).ToList();

                if (accountMap.ContainsKey(trip.Idinitiatoraccount))
                {
                    element.InitiatorFirstName = accountMap[trip.Idinitiatoraccount].Name;
                    element.InitiatorLastName = accountMap[trip.Idinitiatoraccount].Surname;
                }
                else
                {
                    Account acc = AccountLogic.Select(m => m.Id == trip.Idinitiatoraccount).FirstOrDefault();

                    if (acc == null)
                    {
                        continue;
                    }

                    accountMap.Add(trip.Idinitiatoraccount, acc);

                    element.InitiatorFirstName = accountMap[trip.Idinitiatoraccount].Name;
                    element.InitiatorLastName = accountMap[trip.Idinitiatoraccount].Surname;
                }

                element.Participants = VTripparticipantLogic.Select(m => m.Tripid == trip.Id).ToList();

                tripsWithInititator.Add(element);
            }

            return tripsWithInititator;
        }
    }
}