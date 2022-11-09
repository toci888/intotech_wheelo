using Intotech.Common.Bll;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class Collocator : TwoAggrLogicBase<IWorkTripLogic, IUsersCollocationLogic>, ICollocator<IWorkTripLogic, IUsersCollocationLogic>
    {
        private const double DistanceDivisor = 100; // todo make sure about this
        private const int MinutesInterval = 15;
        public Collocator(IWorkTripLogic firstLogic, IUsersCollocationLogic secondLogic) : base(firstLogic, secondLogic)
        {
        }

        public virtual void Collocate(int accountId)
        {
            Worktrip baseWorktrip = FirstLogic.Select(m => m.Id == accountId).First();

            double distance = baseWorktrip.Acceptabledistance.Value / DistanceDivisor;

            List<Worktrip> collocations = FirstLogic.Select(worktrip => worktrip.Idaccount != accountId &&
                baseWorktrip.Fromhour.Value.IsBetween(worktrip.Fromhour.Value.AddMinutes(-MinutesInterval), worktrip.Fromhour.Value.AddMinutes(MinutesInterval)) &&
                baseWorktrip.Tohour.Value.IsBetween(worktrip.Tohour.Value.AddMinutes(-MinutesInterval), worktrip.Tohour.Value.AddMinutes(MinutesInterval)) &&
                (baseWorktrip.Latitudefrom.Value - distance) >= worktrip.Latitudefrom.Value &&
                (baseWorktrip.Latitudefrom.Value + distance) <= worktrip.Latitudefrom.Value// &&
                //(baseWorktrip.Longitudefrom.Value + distance) <= worktrip.Longitudefrom.Value &&
                //(baseWorktrip.Longitudefrom.Value - distance) >= worktrip.Longitudefrom.Value
            ).ToList();
            //52.245876327341477
            // 52.222476545789547
            foreach (Worktrip worktrip in collocations)
            {
                SecondLogic.Insert(new Accountscollocation() { Idaccount = baseWorktrip.Id, Idcollocated = worktrip.Idaccount.Value });
            }
        }
    }
}
