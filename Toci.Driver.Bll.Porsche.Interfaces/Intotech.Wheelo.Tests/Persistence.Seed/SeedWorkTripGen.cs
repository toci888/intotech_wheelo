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
  

            //new seeds

            int divider = 1000;
            for (int i = 0; i < 30; i++)
            {
                double latitudeFrom = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider, 5) + 52.40;

                ModelsEntities.Add(new Worktripgen()
                {
                    Searchid = StringUtils.GetRandomString(32),
                    Idaccount = i+ 1 + offset,
                    Latitudefrom = latitudeFrom,//52.40655122342916,
                    Longitudefrom = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider, 5) + 16.92,//16.92378850458502,
                    Latitudeto = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider + 51.10, 5),//(51.103230555909715,
                    Longitudeto = DoubleUtils.RoundDouble((double)r.Next(1, 9) / divider + 17.03, 5),//(17.032070201490435,
                    Fromhour = new TimeOnly(8, 00),
                    Tohour = new TimeOnly(16, 00),
                    Acceptabledistance = distanceAcc
                });
            }

        //from: 52.406, 16.925 poznan
        //to: 51.107, 17.038 wroclaw

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
