using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Common.Bll.ComplexResponses;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Models.Trip;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ApiSimpleControllerBase<ITripService>
    {
        public TripController(ITripService logic) : base(logic)
        {
        }

        [HttpPost]
        [Route("create-trip")]
        public ReturnedResponse<TripWithParticipantsDto> CreateTrip(TripDto trip)
        {
            return Service.CreateTrip(trip);
        }

        [HttpPatch("confirm-trip-participation")]
        public ReturnedResponse<bool> ConfirmTripParticipation(TripParticipationConfirmationDto tripAccountConfirm)
        {
            return Service.ConfirmTripParticipation(tripAccountConfirm);
        }

        [HttpPost]
        [Route("add-trip-participant")]
        public ReturnedResponse<int> AddTripParticipant(TripParticipantDto tripParticipantDto) //dodałam RR 1.12.22
        {
            return Service.AddTripParticipant(tripParticipantDto.TripId, tripParticipantDto.AccountId);
        }

        [HttpPost]
        [Route("set-trip-not-current")]
        public ReturnedResponse<bool> SetTripNotCurrent(TripParticipantDto tripInitiatorDto) //dodałam RR 1.12.22
        {
            return Service.SetTripNotCurrent(tripInitiatorDto.TripId, tripInitiatorDto.AccountId);
        }

        [HttpGet]
        [Route("get-all-trips/{idAccount}")]
        public ReturnedResponse<List<TripWithParticipantsDto>> GetAllTrips(int idAccount)
        {
            return Service.GetAllTrips(idAccount);
        }

        [HttpGet]
        [Route("get-trip")]
        public ReturnedResponse<TripWithParticipantsDto> GetTrip(int tripId) //dodałam RR 1.12.22
        {
            return Service.GetTrip(tripId);
        }

        [HttpGet]
        [Route("get-initiator-trips")]
        public ReturnedResponse<List<TripWithParticipantsDto>> GetInitiatorTrips(int inititatorAccountId)
        {
            return Service.GetInitiatorTrips(inititatorAccountId);
        }

        [HttpGet]
        [Route("get-trip-participants")]
        public ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId)
        {
            return Service.GetTripParticipants(accountId);
        }
    }
}
