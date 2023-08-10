using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedWorktripgen : SeedWheeloMainLogic<Worktripgen>
    {
        public override void Insert()
        {
            List<Worktripgen> list = new List<Worktripgen>();

            //TODO Here !

            InsertCollection(list);
        }
    }
}