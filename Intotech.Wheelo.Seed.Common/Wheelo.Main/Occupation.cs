using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedOccupation : SeedWheeloMainLogic<Occupation>
    {
        public override void Insert()
        {
            List<Occupation> list = new List<Occupation>()
            {
                new Occupation { Name = "OccupationOne"},
                new Occupation { Name = "OccupationTwo"},
                new Occupation { Name = "OccupationThree"},
                new Occupation { Name = "OccupationFour"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Occupation, bool>> TakeWhereCondition(Occupation searchValue)
        {
            return m => m.Name == searchValue.Name ; 
        }
    }
}