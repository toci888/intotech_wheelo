using Intotech.Wheelo.Bll.Persistence.Interfaces;
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

        public TripManager(ITripLogic tripLogic, ITripparticipantLogic tripparticipantLogic)
        {
            TripLogic = tripLogic;
            TripparticipantLogic = tripparticipantLogic;
        }

        public int AddTripParticipant(int tripId, int accountId)
        {
            return TripparticipantLogic.Insert(new Tripparticipant() { Idtrip = tripId, Idaccount = accountId }).Id;
        }

        public Trip CreateTrip(Trip trip)
        {

            throw new NotImplementedException();
        }
    }
}
