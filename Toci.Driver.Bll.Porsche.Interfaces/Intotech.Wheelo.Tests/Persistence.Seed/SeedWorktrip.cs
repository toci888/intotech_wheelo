using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedWorktrip : SeedLogic<Worktrip>
    {
        private const int distanceAcc = 700;

        public override void Insert()
        {
            List<Worktrip> worktripList = new List<Worktrip>();

            Worktrip wt = new Worktrip() { Idaccount = 2, Latitudefrom = 52.24602984098752, Longitudefrom = 21.08428642005573,
                Latitudeto = 52.20678607141056, Longitudeto = 21.0108489021064, Fromhour = new TimeOnly(8, 0), 
                Tohour = new TimeOnly(16, 0), Acceptabledistance = distanceAcc }; //52.23151900096433, 21.083137973493866
            worktripList.Add(wt);

            worktripList.Add(new Worktrip() { Idaccount = 3, Latitudefrom = 52.24587632734148, Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20478607141056, Longitudeto = 21.0118489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10), Acceptabledistance = distanceAcc});

            worktripList.Add(new Worktrip() { Idaccount = 4, Latitudefrom = 52.281961410186135, Longitudefrom = 21.062964534960436,
                Latitudeto = 52.22478607141056, Longitudeto = 21.0114489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 5, Latitudefrom = 52.281761410186135, Longitudefrom = 21.063964534960436,
                Latitudeto = 52.22478607141056, Longitudeto = 21.0114489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 6, Latitudefrom = 52.281961410186135, Longitudefrom = 21.062964534960436,
                Latitudeto = 52.22478607141056, Longitudeto = 21.0114489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 7, Latitudefrom = 52.285761410186135, Longitudefrom = 21.065964534960436,
                Latitudeto = 52.262478607141056, Longitudeto = 21.1114489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 8, Latitudefrom = 52.2821765457895457, Longitudefrom = 21.082964534960436,
                Latitudeto = 52.22498607141056, Longitudeto = 21.01211789021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 9, Latitudefrom = 52.2824765457895457, Longitudefrom = 21.082664534960436,
                Latitudeto = 52.22458607141056, Longitudeto = 21.01213789021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });
                
            worktripList.Add(new Worktrip() { Idaccount = 1, Latitudefrom = 52.24557632734148, Longitudefrom = 21.086258004124745,
                Latitudeto = 52.20475607141056, Longitudeto = 21.0128489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 10, Latitudefrom = 52.24587632734148, Longitudefrom = 21.087258004124745,
                Latitudeto = 52.2178607141056, Longitudeto = 21.0124489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 11, Latitudefrom = 52.247587632736356, Longitudefrom = 21.084658004124745,
                Latitudeto = 52.22278607141056, Longitudeto = 21.0122489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 12, Latitudefrom = 52.251961410186135, Longitudefrom = 21.064964534960436,
                Latitudeto = 52.22478607141056, Longitudeto = 21.0114489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 13, Latitudefrom = 52.291761410186135, Longitudefrom = 21.063964534960436,
                Latitudeto = 52.22478607141056, Longitudeto = 21.0194489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 14, Latitudefrom = 52.291961410186135, Longitudefrom = 21.064864534960436,
                Latitudeto = 52.23478607141056, Longitudeto = 21.0104489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 15, Latitudefrom = 52.325761410186135, Longitudefrom = 21.065564534960436,
                Latitudeto = 52.233478607141056, Longitudeto = 21.1134489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 16, Latitudefrom = 52.3221765457895457, Longitudefrom = 21.085964534960436,
                Latitudeto = 52.24798607141056, Longitudeto = 21.01811789021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 17, Latitudefrom = 52.2224765457895457, Longitudefrom = 21.082664534960436,
                Latitudeto = 52.24958607141056, Longitudeto = 21.01813789021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });
                
            worktripList.Add(new Worktrip() { Idaccount = 18, Latitudefrom = 52.23557632734148, Longitudefrom = 21.086258004124745,
                Latitudeto = 52.20475607141056, Longitudeto = 21.0178489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 19, Latitudefrom = 52.24588142734148, Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20678607141056, Longitudeto = 21.0148489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip() { Idaccount = 20, Latitudefrom = 52.24587632734148, Longitudefrom = 21.087258004124745,
                Latitudeto = 52.20578607141056, Longitudeto = 21.01718489021064, Fromhour = new TimeOnly(7, 50), 
                Tohour = new TimeOnly(16, 10),
                Acceptabledistance = distanceAcc
            });

            worktripList.Add(new Worktrip()
            {
                Idaccount = 21,
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
            worktripList.Add(new Worktrip()
            {
                Idaccount = 22,
                Latitudefrom = 52.28055122342916,
                Longitudefrom = 20.94278850458502,
                Latitudeto = 52.205230555909715,
                Longitudeto = 21.021070201490435,
                Fromhour = new TimeOnly(8, 00),
                Tohour = new TimeOnly(16, 00),
                Acceptabledistance = distanceAcc
            });

            InsertCollection(worktripList);
        }
    }
}
