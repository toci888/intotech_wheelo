using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
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
        public Trip CreateTrip(TripDto trip)
        {
            return Service.CreateTrip(trip, trip.AccountIds);
        }

        [HttpPost]
        [Route("add-trip-participant")]
        public int AddTripParticipant(TripParticipantDto tripParticipantDto)
        {
            return Service.AddTripParticipant(tripParticipantDto.TripId, tripParticipantDto.AccountId);
        }

        [HttpPost]
        [Route("set-trip-not-current")]
        public bool SetTripNotCurrent(TripParticipantDto tripInitiatorDto)
        {
            return Service.SetTripNotCurrent(tripInitiatorDto.TripId, tripInitiatorDto.AccountId);
        }

        [HttpGet]
        [Route("get-all-trips")]
        public List<Trip> GetAllTrips(int accountId)
        {
            return Service.GetAllTrips(accountId);
        }

        [HttpGet]
        [Route("get-trip")]
        public Trip GetTrip(int tripId)
        {
            return Service.GetTrip(tripId);
        }

        [HttpGet]
        [Route("get-initiator-trips")]
        public List<Trip> GetInitiatorTrips(int inititatorAccountId)
        {
            return Service.GetInitiatorTrips(inititatorAccountId);
        }

        [HttpGet]
        [Route("get-trip-participants")]
        public List<Vtripsparticipant> GetTripParticipants(int accountId)
        {
            return Service.GetTripParticipants(accountId);
        }
    }
}
