using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.Extensions
{
    public static class WorktripgenExtensions
    {
        public static Worktripgen MapFromReader(this IWorktripgenLogic logic, NpgsqlDataReader dataReader)
        {
            Worktripgen result = new Worktripgen();

            result.Idaccount = int.Parse(dataReader["Idaccount"].ToString());
            result.Createdat = DateTime.Parse(dataReader["Createdat"].ToString());
            result.Acceptabledistance = double.Parse(dataReader["Acceptabledistance"].ToString());
            result.Driverpassenger = int.Parse(dataReader["Driverpassenger"].ToString());
            result.Fromhour = TimeOnly.Parse(dataReader["Fromhour"].ToString());
            result.Tohour = TimeOnly.Parse(dataReader["Tohour"].ToString());
            result.Id = int.Parse(dataReader["Id"].ToString());
            result.Cityfrom = dataReader["Cityfrom"].ToString();
            result.Cityto = dataReader["Cityto"].ToString();
            result.Idgeographiclocationfrom = dataReader["Idgeographiclocationfrom"].ToString() != string.Empty ? int.Parse(dataReader["Idgeographiclocationfrom"].ToString()) : 0;
            result.Idgeographiclocationto = dataReader["Idgeographiclocationto"].ToString() != string.Empty ? int.Parse(dataReader["Idgeographiclocationto"].ToString()) : 0;
            result.Latitudefrom = double.Parse(dataReader["Latitudefrom"].ToString());
            result.Latitudeto = double.Parse(dataReader["Latitudeto"].ToString());
            result.Longitudefrom = double.Parse(dataReader["Longitudefrom"].ToString());
            result.Longitudeto = double.Parse(dataReader["Longitudeto"].ToString());
            result.Postcodefrom = dataReader["Postcodefrom"].ToString();
            result.Postcodeto = dataReader["Postcodeto"].ToString();
            result.Streetfrom = dataReader["Streetfrom"].ToString();
            result.Streetto = dataReader["Streetto"].ToString();

            return result;
        }
    }
}
