using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedTrip : SeedWheeloMainLogic<Trip>
    {
        public override void Insert()
        {
            List<Trip> list = new List<Trip>()
            {
                new Trip() { Idinitiatoraccount = 1, Idworktrip = 1, Tripdate = new DateOnly(2023, 6, 15), Iscurrent = true, Fromhour = new TimeOnly(9, 0),
                Tohour = new TimeOnly(18, 0), Summary = "Krótka podróż", Createdat = DateTime.Now, Leftseats = 3 },
                new Trip() { Idinitiatoraccount = 1, Idworktrip = 1, Tripdate = new DateOnly(2023, 6, 10), Iscurrent = true, Fromhour = new TimeOnly(13, 0),
                Tohour = new TimeOnly(4, 0), Summary = "Długa podróż", Createdat = DateTime.Now, Leftseats = 3 },
                new Trip() { Idinitiatoraccount = 1, Idworktrip = 1, Tripdate = new DateOnly(2023, 6, 2), Iscurrent = true, Fromhour = new TimeOnly(2, 0),
                Tohour = new TimeOnly(5, 0), Summary = "Średnia podróż", Createdat = DateTime.Now, Leftseats = 3 },

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Trip, bool>> TakeWhereCondition(Trip searchValue)
        {
            return m => true;
        }
    }
}