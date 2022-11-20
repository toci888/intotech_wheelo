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

        // zad 1 - wczytac z pliku surnames txt do listy Surnames pojedyncze nazwiska per element listy
        // zad 2 - names
        protected void PopulateSurnames()
        {
            string surnames = File.ReadAllText(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Intotech.Wheelo.Tests\Persistence.Seed\RawData\surnames.txt");

            Surnames = surnames.Split("\n").ToList();
        }

        public override void Insert()
        {
            PopulateSurnames();

            List<Account> accounts = new List<Account>()
            {
                new Account() { Name = "Bartek", Surname = "Zapart", Gender = 1, Phone = "12343256", Email = "bzapart@gmail.com", Login = "ghostrider", Password="beatka", Token = "cntgfu347frgwhu293", Idrole = 2 }
            };

            for (int i = 0; i < 50; i++)
            {
                accounts.Add(new Account() { Name = StringUtils.GetRandomText(10), Surname = StringUtils.GetRandomText(8), Gender = i % 2 + 1, Phone = "12343256", Password = StringUtils.GetRandomText(10), Email = StringUtils.GetRandomText(12), Login = StringUtils.GetRandomText(7), Token = StringUtils.GetRandomText(18), Idrole = 2 });
            }

            InsertCollection(accounts);
        }
    }
}
