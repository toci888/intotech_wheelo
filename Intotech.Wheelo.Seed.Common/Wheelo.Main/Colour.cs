using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedColour : SeedWheeloMainLogic<Colour>
    {
        public override void Insert()
        {
            List<Colour> list = new List<Colour>()
            {
                new Colour(){Name = "Green", Rgb = "0,255,0"},
                new Colour(){Name = "Blue", Rgb = "0,0,255"},
                new Colour(){Name = "White", Rgb = "255,255,255"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Colour, bool>> TakeWhereCondition(Colour searchValue)
        {
            return m=> m.Name == searchValue.Name;
        }
    }
}