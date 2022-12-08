using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedFriends : SeedLogic<Friend>
    {
        public override void Insert()
        {
            List<Friend> list = new List<Friend>();

            list.Add(new Friend() { Idaccount = 1, Idfriend = 11 });
            list.Add(new Friend() { Idaccount = 2, Idfriend = 12 });
            list.Add(new Friend() { Idaccount = 3, Idfriend = 13 });
            list.Add(new Friend() { Idaccount = 4, Idfriend = 14 });
            list.Add(new Friend() { Idaccount = 5, Idfriend = 15 });
            list.Add(new Friend() { Idaccount = 6, Idfriend = 16 });
            list.Add(new Friend() { Idaccount = 7, Idfriend = 17 });
            list.Add(new Friend() { Idaccount = 8, Idfriend = 18 });
            list.Add(new Friend() { Idaccount = 9, Idfriend = 19 });
            list.Add(new Friend() { Idaccount = 31, Idfriend = 41 });
            list.Add(new Friend() { Idaccount = 32, Idfriend = 42 });
            list.Add(new Friend() { Idaccount = 33, Idfriend = 43 });
            list.Add(new Friend() { Idaccount = 34, Idfriend = 44 });
            list.Add(new Friend() { Idaccount = 35, Idfriend = 45 });
            list.Add(new Friend() { Idaccount = 36, Idfriend = 46 });
            list.Add(new Friend() { Idaccount = 37, Idfriend = 47 });
            list.Add(new Friend() { Idaccount = 38, Idfriend = 48 });

            foreach (Friend sugg in list)
            {
                sugg.Idfriend += AccountIdOffset;
                //sugg.Idsuggested += AccountIdOffset;
                sugg.Idaccount += AccountIdOffset;

                ModelsEntities.Add(sugg);
            }

            InsertCollection(ModelsEntities);
        }
    }
}
