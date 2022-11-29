using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Common;
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
        protected IVusersCollocationLogic AccountCollocationLogic;

        public Collocator(IWorkTripLogic firstLogic, IUsersCollocationLogic secondLogic,
            IAssociationCalculations associationCalculations, IVusersCollocationLogic accountCollocationLogic) : base(firstLogic, secondLogic)
        {
            AssociationCalculation = associationCalculations;
            AccountCollocationLogic = accountCollocationLogic;
        }

        public virtual ReturnedResponse<List<Vaccountscollocation>> Collocate(int accountId)
        {
            Worktrip baseWorktrip = FirstLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (baseWorktrip == null)
            {
                return new ReturnedResponse<List<Vaccountscollocation>>(null, I18nTranslation.Translation(I18nTags.NoWorkTripData), false);
            }

            double distance = baseWorktrip.Acceptabledistance.Value / DistanceDivisor;

            List<Worktrip> collocations = FirstLogic.Select(worktrip => worktrip.Idaccount.Value != accountId &&
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

                SecondLogic.Insert(new Accountscollocation() { Idaccount = baseWorktrip.Idaccount.Value,
                    Idcollocated = worktrip.Idaccount.Value, Distancefrom = distanceFrom, Distanceto = distanceTo
                });
            }

            return new ReturnedResponse<List<Vaccountscollocation>>(AccountCollocationLogic.Select(m => m.Accountid == accountId).ToList(), "", true);
        }

        public virtual ReturnedResponse<List<Vaccountscollocation>> AddWorkTrip(Worktrip worktrip)
        {
            Worktrip wt = FirstLogic.Insert(worktrip);

            return Collocate(wt.Idaccount.Value);
        }

        public virtual ReturnedResponse<List<Vaccountscollocation>> GetUserAssociations(int accountId)
        {
            return new ReturnedResponse<List<Vaccountscollocation>>(AccountCollocationLogic.Select(m => m.Accountid == accountId || m.Suggestedaccountid == accountId).ToList(), "", true);
        }
    }
}
