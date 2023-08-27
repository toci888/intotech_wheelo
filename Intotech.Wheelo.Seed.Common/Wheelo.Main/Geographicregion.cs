using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedGeographicregion : SeedWheeloMainLogic<Geographicregion>
    {
        public override void Insert()
        {
            List<Geographicregion> list = new List<Geographicregion>()
            {
                new Geographicregion() { Idparent = 0, Name = "LUBELSKIE", Idshit = null, },
                new Geographicregion() { Idparent = 0, Name = "KUJAWSKO POMORSKIE", Idshit = null, },
                new Geographicregion() { Idparent = 0, Name = "DOLNOSLASKIE", Idshit = null, },
                new Geographicregion() { Idparent = 1, Name = "Bavaria", Idshit = null, },
                new Geographicregion() { Idparent = 1, Name = "Bremen", Idshit = null, },
                new Geographicregion() { Idparent = 1, Name = "Hamburg", Idshit = null, },

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Geographicregion, bool>> TakeWhereCondition(Geographicregion searchValue)
        {
            return m=> m.Idparent == searchValue.Idparent && m.Name == searchValue.Name;
        }
    }
}