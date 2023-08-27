using Intotech.Common;
using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedWorktripgen : SeedWheeloMainLogic<Worktripgen>
    {
       
        int distanceAcc = 888;
        Random r = new Random();

        public override void Insert()
        {
            List<Worktripgen> list = new List<Worktripgen>();

            int divider = 1000;
            for (int i = 0; i < 30; i++)
            {
                double latitudeFrom = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider, 5) + 52.40;

                list.Add(new Worktripgen()
                {
                    Searchid = StringUtils.GetRandomString(32),
                    Idaccount = i + 1 + AccountIdOffset,
                    Latitudefrom = latitudeFrom,//52.40655122342916,
                    Longitudefrom = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider, 5) + 16.92,//16.92378850458502,
                    Latitudeto = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider + 51.10, 5),//(51.103230555909715,
                    Longitudeto = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider + 17.03, 5),//(17.032070201490435,
                    Fromhour = new TimeOnly(8, 00),
                    Tohour = new TimeOnly(16, 00),
                    Acceptabledistance = distanceAcc
                });
            }
            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Worktripgen, bool>> TakeWhereCondition(Worktripgen searchValue)
        {
            return m => m.Searchid == searchValue.Searchid;
        }

    }
}