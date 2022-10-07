using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wheelo.Nfs.Database.Persistence;
using Wheelo.Nfs.Database.Persistence.Models;

namespace Wheelo.Test
{
    [TestClass]
    public class postgres
    {
        [TestMethod]
        public void insert()
        {
            PostgresqlRepository<User> repouser = new PostgresqlRepository<User>();

            

            repouser.Insert(new User() {  
                Email = "bzapa@ds.DS", 
                Login = "warrior", 
                Name = "bartek", 
                Password = "beatka", 
                Phone = "731", 
                Surname = "Zapa"
            });









        }
    }
}
