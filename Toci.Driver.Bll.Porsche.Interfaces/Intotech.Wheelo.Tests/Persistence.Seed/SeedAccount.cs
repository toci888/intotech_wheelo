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
                new Account() { Name = "Bartek", Surname = "Zapart", Gender = 1, Method = "wheelo", Phone = "12343256", Email = "bzapart@gmail.com", Password = HashGenerator.HashSHA256("beatka"), Token = "cntgfu347frgwhu293", Idrole = 2 }
            };

            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                accounts.Add(new Account() { Name = Names[rnd.Next(0, Names.Count - 1)], Surname = Surnames[rnd.Next(0, Surnames.Count - 1)], Gender = i % 2 + 1, Phone = "12343256", Password = HashGenerator.HashSHA256("beatka"), Method = "wheelo", Email = StringUtils.GetRandomText(12), Token = StringUtils.GetRandomText(18), Idrole = 2 });
            }

            InsertCollection(accounts);
        }
    }
}
