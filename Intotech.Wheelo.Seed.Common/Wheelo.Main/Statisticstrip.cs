using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedStatisticstrip : SeedWheeloMainLogic<Statisticstrip>
    {
        public override void Insert()
        {
            List<Statisticstrip> list = new List<Statisticstrip>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}