using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedStatisticstrip : SeedWheeloMainLogic<Statisticstrip>
    {
        public override void Insert()
        {
            List<Statisticstrip> list = new List<Statisticstrip>()
            {
                new Statisticstrip() { Tripdate = new DateOnly(2023, 6, 15), Tripcars = 1, Trippeople = 3, Idgeographicregion = 2 },
                new Statisticstrip() { Tripdate = new DateOnly(2023, 6, 10), Tripcars = 2, Trippeople = 2, Idgeographicregion = 2 },
                new Statisticstrip() { Tripdate = new DateOnly(2023, 4, 20), Tripcars = 5, Trippeople = 1, Idgeographicregion = 2 },
                new Statisticstrip() { Tripdate = new DateOnly(2023, 1, 3), Tripcars = 2, Trippeople = 0, Idgeographicregion = 2 }
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Statisticstrip, bool>> TakeWhereCondition(Statisticstrip searchValue)
        {
            return m=> m.Id == searchValue.Id;
        }
    }
}