using System.Linq.Expressions;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public class SeedAccountscarslocation : SeedWheeloMainLogic<Accountscarslocation>
    {
        public override void Insert()
        {
            List<Accountscarslocation> list = new List<Accountscarslocation>()
            {
                new Accountscarslocation { Idaccount = 1 + AccountIdOffset, Email = "bzapart@gmail.com", Name = "Bartek", Surname = "Zapart", Registrationplate= "MBK 1320A", Availableseats = 2, Cityfrom = "Poznań",
                Streetfrom = "3 Maja" , Cityto = "Gdańsk", Streetto = "Gdańska", Brand = "Opel", Model = "Vectra", Colour = "Green"},
                new Accountscarslocation { Idaccount = 2 + AccountIdOffset, Email = "warriorr@poczta.fm", Name = "Wojtek", Surname = "Ruchaіa", Registrationplate= "RNI KA93", Availableseats = 3, Cityfrom = "Rzeszów",
                Streetfrom = "Czerwona" , Cityto = "Warszawa", Streetto = "Nadwiślańska", Brand = "Volksvagen", Model = "Passat", Colour = "Blue"},
                new Accountscarslocation { Idaccount = 3  + AccountIdOffset, Email = "bartek@gg.pl", Name = "Julia", Surname = "Wesoіa", Registrationplate= "WMZ MK20", Availableseats = 1, Cityfrom = "Warszawa",
                Streetfrom = "Zielona" , Cityto = "Kraków", Streetto = "Gdańska", Brand = "Nissan", Model = "Micra", Colour = "White"}
            };

            //TODO Here !

            InsertCollection(list);
        }
        public override Expression<Func<Accountscarslocation, bool>> TakeWhereCondition(Accountscarslocation searchValue)
        {
            return m=> m.Email == searchValue.Email;
        }
    }
}