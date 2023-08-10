using Intotech.Wheelo.Bll.Persistence;
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
    public class InstantOccasion : IInstantOccasion
    {
        private static int timeInterval = 15;

        protected IAccountscollocationLogic UsersCollocationLogic;
        protected ITripLogic TripsLogic;
        protected ITripparticipantLogic TripparticipantLogic;

        public InstantOccasion(IAccountscollocationLogic usersCollocationLogic, ITripLogic tripsLogic, 
            ITripparticipantLogic tripparticipantLogic)
        {
            UsersCollocationLogic = usersCollocationLogic;
            TripsLogic = tripsLogic;
            TripparticipantLogic = tripparticipantLogic;
        }

        public virtual int AddOccasion(int tripId, int occasionAccountId)
        {
            Trip trip = TripsLogic.Select(m => m.Id == tripId).First();

            if (trip.Leftseats > 0)
            {
                trip.Leftseats--;
                TripsLogic.Update(trip);
            }

            return TripparticipantLogic.Insert(new Tripparticipant() 
            { 
                Idaccount = occasionAccountId, 
                Idtrip = tripId,
                Isoccasion = true
            }).Id;
        }

        public virtual List<Trip> FindOccasionalTrips(int accountId, TimeOnly timeFromTo, bool fromTo) // from to true => from, false => to
        {
            List<int> accountCollocations = UsersCollocationLogic.Select(m => m.Idaccount == accountId).
                Select(m => m.Idcollocated).ToList();

            if (fromTo)
            {
                return TripsLogic.Select(m => accountCollocations.Contains(m.Idinitiatoraccount) &&
                m.Leftseats.Value > 0 && m.Iscurrent.Value && 
                m.Fromhour.Value.IsBetween(timeFromTo.AddMinutes(-timeInterval), timeFromTo.AddMinutes(timeInterval)) &&
                m.Tripdate == new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToList();
            }

            return TripsLogic.Select(m => accountCollocations.Contains(m.Idinitiatoraccount) &&
                m.Leftseats.Value > 0 && m.Iscurrent.Value &&
                m.Tohour.Value.IsBetween(timeFromTo.AddMinutes(-timeInterval), timeFromTo.AddMinutes(timeInterval)) &&
                m.Tripdate == new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToList();
        }


    }
}
