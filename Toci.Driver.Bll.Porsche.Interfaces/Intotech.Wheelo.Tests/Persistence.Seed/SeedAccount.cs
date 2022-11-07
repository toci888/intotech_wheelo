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
        public override void Insert()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account() { Name = "Bartek", Surname = "Zapart", Phone = "12343256", Email = "bzapart@gmail.com", Login = "ghostrider", Password="beatka", Token = "cntgfu347frgwhu293", Idrole = 2 }
            };

            for (int i = 0; i < 50; i++)
            {
                accounts.Add(new Account() { Name = StringUtils.GetRandomText(10), Surname = StringUtils.GetRandomText(8), Phone = "12343256", Password = StringUtils.GetRandomText(10), Email = StringUtils.GetRandomText(12), Login = StringUtils.GetRandomText(7), Token = StringUtils.GetRandomText(18), Idrole = 2 });
            }

            InsertCollection(accounts);
        }
    }
}
