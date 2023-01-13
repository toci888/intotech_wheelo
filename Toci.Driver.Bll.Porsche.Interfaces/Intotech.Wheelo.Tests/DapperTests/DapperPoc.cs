using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Intotech.Wheelo.Tests.DapperTests
{
    [TestClass]
    public class DapperPoc
    {
        [TestMethod]
        public void Test()
        {
            //Dapper.SqlBuilder 
            //SqlConnection 
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
            connection.Open();

            int accountId = 1000000014;

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "delete from Accountscollocations where Idaccount = " + accountId + " or Idcollocated = " + accountId;

            int result = command.ExecuteNonQuery();
        }

        //protected virtual SqlConnection GetPostgreConnection()
        //{
            
        //}
    }
}
