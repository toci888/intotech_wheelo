using Intotech.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedWorkTripGen : SeedLogic<Worktripgen>
    {
        int offset = 1000000000;
        int distanceAcc = 888;
        Random r = new Random();

        public override void Insert()
        {
            Worktripgen wt = new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 2 + offset,
                Latitudefrom = 52.24602984098752,
                Longitudefrom = 21.08428642005573,
                Latitudeto = 52.20678607141056,
                Longitudeto = 21.0108489021064,
                Fromhour = new TimeOnly(8, 0),
                Tohour = new TimeOnly(16, 0),
                Acceptabledistance = distanceAcc
            }; //52.23151900096433, 21.083137973493866

            ModelsEntities.Add(wt);

            //new seeds

            int divider = 1000;
            for (int i = 0; i < 30; i++)
            {
                ModelsEntities.Add(new Worktripgen()
                {
                    Searchid = StringUtils.GetRandomString(32),
                    Idaccount = r.Next(0, 32) + offset,
                    Latitudefrom = r.NextDouble() + 52,//52.40655122342916,
                    Longitudefrom = r.NextDouble() + 16,//16.92378850458502,
                    Latitudeto = r.NextDouble() + 51,//(51.103230555909715,
                    Longitudeto = r.NextDouble() + 17,//(17.032070201490435,
                    Fromhour = new TimeOnly(8, 00),
                    Tohour = new TimeOnly(16, 00),
                    Acceptabledistance = distanceAcc
                });
            }

            // int result = r.Next(0, 3) * 15;

            //var result = (r.NextDouble()) / divider;

            /*
             {"startLocation":{"place_id":"ChIJtwrh7NJEBEcR0b80A5gx6qQ","lat":"52.406376","lon":"16.925169","display_name":"Poznań, 62",
            "address":{"name":"Poznań, 62","house_number":null,"road":null,"city":"Poznań","state":"Wielkopolskie","postcode":"62","country":"Polska",
            "country_code":null}},"endLocation":{"place_id":"ChIJv4q11MLpD0cR9eAFwq5WCbc","lat":"51.107883","lon":"17.038538","display_name":"Wrocław, 51","address":{"name":"Wrocław, 51","house_number":null,"road":null,"city":"Wrocław","state":"Dolnośląskie","postcode":"51","country":"Polska","country_code":null}},
            "startLocationTime":"14:39",
            "endLocationTime":"16:00","idAccount":1000000047,"acceptableDistance":800}
*/
            InsertCollection(ModelsEntities);
        }
    }
}
