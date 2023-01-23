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

            //1
            int i = 1;

            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(8, 0),
                Tohour = new TimeOnly(16, 0),
                Idinitiatoraccount = 1 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            }) ;
            //2
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(7, 0),
                Tohour = new TimeOnly(10, 0),
                Idinitiatoraccount = 2 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //3
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(17, 0),
                Tohour = new TimeOnly(18, 0),
                Idinitiatoraccount = 3 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //4
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(14, 0),
                Tohour = new TimeOnly(15, 0),
                Idinitiatoraccount = 4 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //5
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(11, 0),
                Tohour = new TimeOnly(12, 0),
                Idinitiatoraccount = 5 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //6
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(21, 0),
                Tohour = new TimeOnly(22, 0),
                Idinitiatoraccount = 6 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //7
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(16, 0),
                Tohour = new TimeOnly(17, 0),
                Idinitiatoraccount = 7 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //8
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(13, 0),
                Tohour = new TimeOnly(14, 0),
                Idinitiatoraccount = 8 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //9
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(18, 0),
                Tohour = new TimeOnly(20, 0),
                Idinitiatoraccount = 9 + AccountIdOffset,
                Idworktrip = i++,
                Iscurrent = true,
                Leftseats = 3,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });

            for (int j = 0; j < 20; j++)
            {
                tripList.Add(new Trip()
                {
                    Fromhour = new TimeOnly(8, 0),
                    Tohour = new TimeOnly(16, 0),
                    Idinitiatoraccount = 10 + j + AccountIdOffset,
                    Idworktrip = i++,
                    Iscurrent = true,
                    Leftseats = 3,
                    Tripdate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1)
                });

            }

            // ?

            InsertCollection(tripList); 
        }
    }
}
