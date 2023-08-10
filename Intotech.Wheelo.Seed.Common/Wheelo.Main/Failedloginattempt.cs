using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedFailedloginattempt : SeedWheeloMainLogic<Failedloginattempt>
    {
        public override void Insert()
        {
            List<Failedloginattempt> list = new List<Failedloginattempt>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}