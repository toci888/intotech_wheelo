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

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 3 + offset,
                Latitudefrom = 52.24587632734148,
                Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20478607141056,
                Longitudeto = 21.0118489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 4 + offset,
                Latitudefrom = 52.281961410186135,
                Longitudefrom = 21.062964534960436,
                Latitudeto = 52.22478607141056,
                Longitudeto = 21.0114489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 5 + offset,
                Latitudefrom = 52.281761410186135,
                Longitudefrom = 21.063964534960436,
                Latitudeto = 52.22478607141056,
                Longitudeto = 21.0114489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 6 + offset,
                Latitudefrom = 52.281961410186135,
                Longitudefrom = 21.062964534960436,
                Latitudeto = 52.22478607141056,
                Longitudeto = 21.0114489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 7 + offset,
                Latitudefrom = 52.285761410186135,
                Longitudefrom = 21.065964534960436,
                Latitudeto = 52.262478607141056,
                Longitudeto = 21.1114489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 8 + offset,
                Latitudefrom = 52.2821765457895457,
                Longitudefrom = 21.082964534960436,
                Latitudeto = 52.22498607141056,
                Longitudeto = 21.01211789021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 9 + offset,
                Latitudefrom = 52.2824765457895457,
                Longitudefrom = 21.082664534960436,
                Latitudeto = 52.22458607141056,
                Longitudeto = 21.01213789021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 1 + offset,
                Latitudefrom = 52.24557632734148,
                Longitudefrom = 21.086258004124745,
                Latitudeto = 52.20475607141056,
                Longitudeto = 21.0128489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 10 + offset,
                Latitudefrom = 52.24587632734148,
                Longitudefrom = 21.087258004124745,
                Latitudeto = 52.2178607141056,
                Longitudeto = 21.0124489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 11 + offset,
                Latitudefrom = 52.247587632736356,
                Longitudefrom = 21.084658004124745,
                Latitudeto = 52.22278607141056,
                Longitudeto = 21.0122489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 12 + offset,
                Latitudefrom = 52.251961410186135,
                Longitudefrom = 21.064964534960436,
                Latitudeto = 52.22478607141056,
                Longitudeto = 21.0114489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 13 + offset,
                Latitudefrom = 52.291761410186135,
                Longitudefrom = 21.063964534960436,
                Latitudeto = 52.22478607141056,
                Longitudeto = 21.0194489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 14 + offset,
                Latitudefrom = 52.291961410186135,
                Longitudefrom = 21.064864534960436,
                Latitudeto = 52.23478607141056,
                Longitudeto = 21.0104489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 15 + offset,
                Latitudefrom = 52.325761410186135,
                Longitudefrom = 21.065564534960436,
                Latitudeto = 52.233478607141056,
                Longitudeto = 21.1134489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 16 + offset,
                Latitudefrom = 52.3221765457895457,
                Longitudefrom = 21.085964534960436,
                Latitudeto = 52.24798607141056,
                Longitudeto = 21.01811789021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 17 + offset,
                Latitudefrom = 52.2224765457895457,
                Longitudefrom = 21.082664534960436,
                Latitudeto = 52.24958607141056,
                Longitudeto = 21.01813789021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 18 + offset,
                Latitudefrom = 52.23557632734148,
                Longitudefrom = 21.086258004124745,
                Latitudeto = 52.20475607141056,
                Longitudeto = 21.0178489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 19 + offset,
                Latitudefrom = 52.24588142734148,
                Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20678607141056,
                Longitudeto = 21.0148489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 20 + offset,
                Latitudefrom = 52.24587632734148,
                Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20578607141056,
                Longitudeto = 21.01718489021064,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 21 + offset,
                Latitudefrom = 52.28116318542944,
                Longitudefrom = 20.948562842253683,
                Latitudeto = 52.20705299583536,
                Longitudeto = 21.020123977394373,
                Fromhour = new TimeOnly(7, 50),
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });
            // from dist 410,6m
            // to 218,52
            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 22 + offset,
                Latitudefrom = 52.28055122342916,
                Longitudefrom = 20.94278850458502,
                Latitudeto = 52.205230555909715,
                Longitudeto = 21.021070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 23 + offset,
                Latitudefrom = 52.40655122342916,
                Longitudefrom = 16.92578850458502,
                Latitudeto = 51.107230555909715,
                Longitudeto = 17.038070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 24 + offset,
                Latitudefrom = 52.41055122342916,
                Longitudefrom = 16.92978850458502,
                Latitudeto = 51.104230555909715,
                Longitudeto = 17.034070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 25 + offset,
                Latitudefrom = 52.40455122342916,
                Longitudefrom = 16.92178850458502,
                Latitudeto = 51.102230555909715,
                Longitudeto = 17.031070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 26 + offset,
                Latitudefrom = 52.40155122342916,
                Longitudefrom = 16.92378850458502,
                Latitudeto = 51.109230555909715,
                Longitudeto = 17.036070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 27 + offset,
                Latitudefrom = 52.40555122342916,
                Longitudefrom = 16.92578850458502,
                Latitudeto = 51.105230555909715,
                Longitudeto = 17.035070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 28 + offset,
                Latitudefrom = 52.40155122342916,
                Longitudefrom = 16.92978850458502,
                Latitudeto = 51.101230555909715,
                Longitudeto = 17.032070201490435,
                Fromhour = new TimeOnly(7, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });
            //new seeds
            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 29 + offset,
                Latitudefrom = 52.40255122342916,
                Longitudefrom = 16.92878850458502,
                Latitudeto = 51.102230555909715,
                Longitudeto = 17.035070201490435,
                Fromhour = new TimeOnly(7, 05),
                Tohour = new TimeOnly(10, 00),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 30 + offset,
                Latitudefrom = 52.40155122342916,
                Longitudefrom = 16.92978850458502,
                Latitudeto = 51.103230555909715,
                Longitudeto = 17.036070201490435,
                Fromhour = new TimeOnly(7, 15),
                Tohour = new TimeOnly(7, 30),
                Acceptabledistance = distanceAcc
            });

            ModelsEntities.Add(new Worktripgen()
            {
                Searchid = StringUtils.GetRandomString(32),
                Idaccount = 30 + offset,
                Latitudefrom = 52.40055122342916,
                Longitudefrom = 16.92078850458502,
                Latitudeto = 51.100230555909715,
                Longitudeto = 17.030070201490435,
                Fromhour = new TimeOnly(6, 15),
                Tohour = new TimeOnly(7, 00),
                Acceptabledistance = distanceAcc
            });

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
