using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheelo.Nfs.Database.Persistence;
using Wheelo.Nfs.Database.Persistence.Models;
using System.Net.Http;

namespace Wheelo.Test.Generator
{
    [TestClass]
    public class SubZero
    {
        protected JohnnyCage FinishHim = new JohnnyCage();

        [TestMethod]
        public async Task BrutalityAsync()
        {
            Fatality(250);
        }

        public int Fatality(int numRows)
        {

            Random raiden = new Random();

            for (int i = 50 ; i < numRows; i++) // FROM 50 !
            {

                //52.7612628 sz       52.8785255
                //15.2662996 dl       15.5325925

                const string chars = "0123456789";

                string coordinateXfrom = string.Empty;
                string coordinateYfrom = string.Empty;

                string coordinateXto = string.Empty;
                string coordinateYto = string.Empty;

                    coordinateXfrom += "52.";
                    coordinateYfrom += "15.";

                    coordinateXto += "52.";
                    coordinateYto += "15.";

                for (int j = 0; j < 8; j++) // create 52.XXXXXXX, 15.XXXXXXXXX   FROM
                {
                    int randomAfterPeriod = raiden.Next(0, chars.Length - 1);

                    coordinateXfrom += chars[randomAfterPeriod];
                    coordinateYfrom += chars[randomAfterPeriod];
                }


                for (int j = 0; j < 8; j++) // create 52.XXXXXXX, 15.XXXXXXXXX   TO
                {
                    int randomAfterPeriod = raiden.Next(0, chars.Length - 1);

                    coordinateXto += chars[randomAfterPeriod];
                    coordinateYto += chars[randomAfterPeriod];
                }


                string Email = FinishHim.GetRandomWord(8);
                string Login = FinishHim.GetRandomWord(5);
                string Name = FinishHim.GetRandomWord(5);
                string Passoword = FinishHim.GetRandomWord(5);
                string Surname = FinishHim.GetRandomWord(5);
                string phone = FinishHim.GetRandomWord(5);

                User testUser = new User() {

                    Email = Email + i,
                    Login = Login + i,
                    Name = Name + i,
                    Password = Passoword + i,
                    Surname = Surname + i,
                    Phone = phone + i,
                };


                Userslocation location1 = new Userslocation();

                    location1.Coordinatesfrom = coordinateXfrom + ", " + coordinateYfrom;
                    location1.Coordinatesto = coordinateXto + ", " + coordinateYto;

                testUser.Userslocations.Add(location1);


                PostgresqlRepository <User> repouser = new PostgresqlRepository<User>();
                repouser.Insert(testUser);
            }

            return 1;

        }
    }
}