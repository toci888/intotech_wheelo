using Intotech.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedAccount : SeedLogic<Account>
    {
        protected List<string> Surnames = new List<string>();
        protected List<string> Names = new List<string>();

        // zad 1 - wczytac z pliku surnames txt do listy Surnames pojedyncze nazwiska per element listy
        // zad 2 - names
        protected void PopulateSurnames()
        {
            string surnames = File.ReadAllText(@"../../../../Intotech.Wheelo.Tests/Persistence.Seed/RawData/surnames.txt");

            Surnames = surnames.Split("\n").Select(m => m.Trim()).ToList();
        }

        protected void PopulateNames()
        {
            string names = File.ReadAllText(@"../../../../Intotech.Wheelo.Tests/Persistence.Seed/RawData/names.txt");

            Names = names.Split("\n").Select(m => m.Trim()).ToList();
        }

        public override void Insert()
        {
            PopulateSurnames();
            PopulateNames();
            //22CE8D06972A4DEF08FD462C470E60ED1849700D18D96FB472778DB639D1830C
            List<Account> accounts = new List<Account>()
            {
                new Account() { Name = "Bartek", Surname = "Zapart", Email = "bzapart@gmail.com", Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Emailconfirmed = true, Verificationcode = 8888, Refreshtoken = "cntgfu347frgwhu293", Idrole = 1 },
                new Account() { Name = "Wojtek", Surname = "Ruchała", Email = "warriorr@poczta.fm", Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Emailconfirmed = true, Verificationcode = 8888, Refreshtoken = "ef2456t2tewtt24tt4", Idrole = 1 }

            };

            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                accounts.Add(new Account() { Name = Names[rnd.Next(0, Names.Count - 1)], Surname = Surnames[rnd.Next(0, Surnames.Count - 1)], Password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2", Email = StringUtils.GetRandomText(12), Refreshtoken = StringUtils.GetRandomText(18), Idrole = 1 });
            }

            InsertCollection(accounts);
        }
    }
}
