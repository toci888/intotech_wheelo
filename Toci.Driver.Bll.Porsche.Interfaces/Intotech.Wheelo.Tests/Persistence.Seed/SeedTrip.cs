﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedTrip : SeedLogic<Trip>
    {
        public override void Insert()
        {
            List<Trip> tripList = new List<Trip>();

            //1
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(8, 0),
                Tohour = new TimeOnly(16, 0),
                Idinitiatoraccount = 1,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            }) ;
            //2
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(7, 0),
                Tohour = new TimeOnly(10, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //3
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(17, 0),
                Tohour = new TimeOnly(18, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //4
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(14, 0),
                Tohour = new TimeOnly(15, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //5
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(11, 0),
                Tohour = new TimeOnly(12, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //6
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(21, 0),
                Tohour = new TimeOnly(22, 0),
                Idinitiatoraccount = 3,
                Iscurrent = true,
                Leftseats = 2,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //7
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(16, 0),
                Tohour = new TimeOnly(17, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //8
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(17, 0),
                Tohour = new TimeOnly(21, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 1,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
            //9
            tripList.Add(new Trip()
            {
                Fromhour = new TimeOnly(18, 0),
                Tohour = new TimeOnly(20, 0),
                Idinitiatoraccount = 2,
                Iscurrent = true,
                Leftseats = 3,
                Tripdate = new DateOnly(2022, 11, DateTime.Now.Day + 1)
            });
           
            // ?

            InsertCollection(tripList);
        }
    }
}
