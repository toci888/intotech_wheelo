using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedVcarowner : SeedWheeloMainLogic<Vcarowner>
    {
        public override void Insert()
        {
            List<Vcarowner> list = new List<Vcarowner>()
            {
                new Vcarowner { Name = "Tomek", Surname = "Kozdra", Availableseats = 3, Registrationplate = "MBK 345SW", Brand = "Volkswagen", Model = "Passat",
                Colour = "Black", Rgb = "255,255,255"},

                new Vcarowner { Name = "Zbyszek", Surname = "Zybura", Availableseats = 1, Registrationplate = "WMZ 4675", Brand = "Opel", Model = "Vectra",
                Colour = "Red", Rgb = "255,123,255"},

                new Vcarowner { Name = "Kuba", Surname = "Bartosz", Availableseats = 2, Registrationplate = "RNI KA93W", Brand = "Citroen", Model = "C4",
                Colour = "White", Rgb = "255,0,255"},

                new Vcarowner { Name = "Wiesiek", Surname = "Burak", Availableseats = 3, Registrationplate = "MZK 9087G", Brand = "Renault", Model = "Clio",
                Colour = "Yellow", Rgb = "123,0,255"},

            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Vcarowner, bool>> TakeWhereCondition(Vcarowner searchValue)
        {
            return m => m.Registrationplate == searchValue.Registrationplate;
        }
    }
}