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
    public class InstantOccasion : IInstantOccasion
    {
        private static int timeInterval = 15;

        protected IUsersCollocationLogic UsersCollocationLogic;
        protected ITripLogic TripsLogic;

        public InstantOccasion(IUsersCollocationLogic usersCollocationLogic, ITripLogic tripsLogic)
        {
            UsersCollocationLogic = usersCollocationLogic;
            TripsLogic = tripsLogic;
        }

        public virtual List<Trip> FindOccasionalTrips(int accountId, TimeOnly timeFromTo, bool fromTo) // from to true => from, false => to
        {
            List<int> accountCollocations = UsersCollocationLogic.Select(m => m.Idaccount == accountId).Select(m => m.Idcollocated).ToList();

            if (fromTo)
            {
                return TripsLogic.Select(m => accountCollocations.Contains(m.Idinitiatoraccount.Value) &&
                m.Leftseats.Value > 0 && m.Iscurrent.Value && 
                m.Fromhour.Value.IsBetween(timeFromTo.AddMinutes(-timeInterval), timeFromTo.AddMinutes(timeInterval)) &&
                m.Tripdate == new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToList();
            }

            return TripsLogic.Select(m => accountCollocations.Contains(m.Idinitiatoraccount.Value) &&
                m.Leftseats.Value > 0 && m.Iscurrent.Value &&
                m.Tohour.Value.IsBetween(timeFromTo.AddMinutes(-timeInterval), timeFromTo.AddMinutes(timeInterval)) &&
                m.Tripdate == new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToList();
        }
    }
}
