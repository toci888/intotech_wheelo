using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Common.Bll.ComplexResponses;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ApiSimpleControllerBase<ITripManager>
    {
        public TripController(ITripManager logic) : base(logic)
        {
        }

        [HttpPost]
        [Route("create-trip")]
        public ReturnedResponse<Trip> CreateTrip(TripDto trip)
        {
            return Service.CreateTrip(trip, trip.AccountIds);
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
        [Route("get-all-trips")]
        public ReturnedResponse<List<Trip>> GetAllTrips(int accountId)
        {
            return Service.GetAllTrips(accountId);
        }

        [HttpGet]
        [Route("get-trip")]
        public ReturnedResponse<Trip> GetTrip(int tripId) //dodałam RR 1.12.22
        {
            return Service.GetTrip(tripId);
        }

        [HttpGet]
        [Route("get-initiator-trips")]
        public ReturnedResponse<List<Trip>> GetInitiatorTrips(int inititatorAccountId)
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
