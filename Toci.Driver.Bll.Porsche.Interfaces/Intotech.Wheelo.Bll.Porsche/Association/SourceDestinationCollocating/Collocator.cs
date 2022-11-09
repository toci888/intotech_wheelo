using Intotech.Common.Bll;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class Collocator : TwoAggrLogicBase<IWorkTripLogic, IUsersCollocationLogic>, ICollocator<IWorkTripLogic, IUsersCollocationLogic>
    {
        private const double DistanceDivisor = 100000; // todo make sure about this
        private const int MinutesInterval = 15;
        private const int DistanceNormalize = 1000;

        protected IAssociationCalculations AssociationCalculation;

        public Collocator(IWorkTripLogic firstLogic, IUsersCollocationLogic secondLogic, IAssociationCalculations associationCalculations) : base(firstLogic, secondLogic)
        {
            AssociationCalculation = associationCalculations;
        }

        public virtual void Collocate(int accountId)
        {
            Worktrip baseWorktrip = FirstLogic.Select(m => m.Idaccount == accountId).First();

            double distance = baseWorktrip.Acceptabledistance.Value / DistanceDivisor;

            List<Worktrip> collocations = FirstLogic.Select(worktrip => worktrip.Idaccount != accountId &&
                baseWorktrip.Fromhour.Value.IsBetween(worktrip.Fromhour.Value.AddMinutes(-MinutesInterval), worktrip.Fromhour.Value.AddMinutes(MinutesInterval)) &&
                baseWorktrip.Tohour.Value.IsBetween(worktrip.Tohour.Value.AddMinutes(-MinutesInterval), worktrip.Tohour.Value.AddMinutes(MinutesInterval)) &&
                (baseWorktrip.Latitudefrom.Value - distance) <= worktrip.Latitudefrom.Value &&
                (baseWorktrip.Latitudefrom.Value + distance) >= worktrip.Latitudefrom.Value &&
                (baseWorktrip.Longitudefrom.Value + distance) >= worktrip.Longitudefrom.Value &&
                (baseWorktrip.Longitudefrom.Value - distance) <= worktrip.Longitudefrom.Value &&

                (baseWorktrip.Latitudeto.Value - distance) <= worktrip.Latitudeto.Value &&
                (baseWorktrip.Latitudeto.Value + distance) >= worktrip.Latitudeto.Value &&
                (baseWorktrip.Longitudeto.Value + distance) >= worktrip.Longitudeto.Value &&
                (baseWorktrip.Longitudeto.Value - distance) <= worktrip.Longitudeto.Value
            ).ToList();

            //52.245876327341477
            // 52.222476545789547
            foreach (Worktrip worktrip in collocations)
            {
                decimal distanceFrom = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(baseWorktrip.Latitudefrom.Value, 
                    baseWorktrip.Longitudefrom.Value, worktrip.Latitudefrom.Value, worktrip.Longitudefrom.Value) * DistanceNormalize;

                decimal distanceTo = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(baseWorktrip.Latitudeto.Value,
                    baseWorktrip.Longitudeto.Value, worktrip.Latitudeto.Value, worktrip.Longitudeto.Value) * DistanceNormalize;

                SecondLogic.Insert(new Accountscollocation() { Idaccount = baseWorktrip.Id, 
                    Idcollocated = worktrip.Idaccount.Value, Distancefrom = distanceFrom, Distanceto = distanceTo
                });
            }
        }
    }
}
