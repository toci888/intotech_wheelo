using Intotech.Common.Bll.ComplexResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Models.Trip;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ITripService
    {
        ReturnedResponse<TripWithParticipantsDto> CreateTrip(TripDto trip);
        ReturnedResponse<bool> ConfirmTripParticipation(TripParticipationConfirmationDto tripAccountConfirm);
        ReturnedResponse<int> AddTripParticipant(int tripId, int accountId);

        ReturnedResponse<bool> SetTripNotCurrent(int tripId, int inititatorAccountId);
    
        ReturnedResponse<List<TripWithParticipantsDto>> GetAllTrips(int accountId);

        ReturnedResponse<TripWithParticipantsDto> GetTrip(int tripId);
        //^ dodałam RR 1.12.22
        ReturnedResponse<List<TripWithParticipantsDto>> GetInitiatorTrips(int inititatorAccountId);

        ReturnedResponse<List<Vtripsparticipant>> GetTripParticipants(int accountId);
    }
}
