using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedTrip : SeedLogic<Trip>
    {
        public override void Insert()
        {
            List<Trip> tripList = new List<Trip>();

            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(8, 0),
                Tohour = new TimeOnly(16, 0),
                Idinitiatoraccount = 1,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            }) ;

            // ?

            InsertCollection(tripList);
        }
    }
}
