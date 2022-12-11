using Intotech.Common;
using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating
{
    public class Collocator : TwoAggrLogicBase<IWorkTripLogic, IAccountscollocationLogic>, ICollocator<IWorkTripLogic, IAccountscollocationLogic>
    {
        private const double DistanceDivisor = 100000; // todo make sure about this
        private const int MinutesInterval = 15;
        private const int DistanceNormalize = 1000;

        protected IAssociationCalculations AssociationCalculation;
        protected IVusersCollocationLogic AccountCollocationLogic;
        protected IVaccountscollocationsworktripLogic VaccountscollocationsworktripLogic;
        protected IAssociationMapDataSubService AssociationMapDataSubService;

        public Collocator(IWorkTripLogic firstLogic, IAccountscollocationLogic secondLogic,
            IAssociationCalculations associationCalculations, 
            IVusersCollocationLogic accountCollocationLogic,
            IVaccountscollocationsworktripLogic vaccountscollocationsworktripLogic,
            IAssociationMapDataSubService associationMapDataSubService) : base(firstLogic, secondLogic)
        {
            AssociationCalculation = associationCalculations;
            AccountCollocationLogic = accountCollocationLogic;
            VaccountscollocationsworktripLogic = vaccountscollocationsworktripLogic;
            AssociationMapDataSubService = associationMapDataSubService;
        }

        public virtual void Collocate(int accountId, string searchId)
        {
            Worktrip baseWorktrip = FirstLogic.Select(m => m.Idaccount == accountId && m.Searchid == searchId).FirstOrDefault();

            if (baseWorktrip == null)
            {
                return; // new ReturnedResponse<List<Vaccountscollocation>>(null, I18nTranslation.Translation(I18nTags.NoWorkTripData), false, ErrorCodes.WorkTripFormNotFilled);//Nie uzupełniłeś formularza ..... ?
            }

            double distance = baseWorktrip.Acceptabledistance.Value / DistanceDivisor;

         
            List<Worktrip> collocations = new List<Worktrip>();
                
             /*   FirstLogic.Select(worktrip => worktrip.Idaccount.Value != accountId &&
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
             */

            //52.245876327341477
            // 52.222476545789547
            /*foreach (Worktrip worktrip in collocations)
            {
                if (!IsCollocationDuplicate(baseWorktrip.Idaccount.Value, worktrip.Idaccount.Value))
                {
                    decimal distanceFrom = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(baseWorktrip.Latitudefrom.Value,
                        baseWorktrip.Longitudefrom.Value, worktrip.Latitudefrom.Value, worktrip.Longitudefrom.Value) * DistanceNormalize;

                    decimal distanceTo = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(baseWorktrip.Latitudeto.Value,
                        baseWorktrip.Longitudeto.Value, worktrip.Latitudeto.Value, worktrip.Longitudeto.Value) * DistanceNormalize;

                    SecondLogic.Insert(new Accountscollocation()
                    {
                        Idaccount = baseWorktrip.Idaccount.Value,
                        Idcollocated = worktrip.Idaccount.Value,
                        Distancefrom = distanceFrom,
                        Distanceto = distanceTo
                    });
                }
            }*/
        }

        protected virtual bool IsCollocationDuplicate(int accountId, int collocatedAccountId)
        {
            return SecondLogic.Select(m => m.Idaccount == accountId && m.Idcollocated == collocatedAccountId).FirstOrDefault() != null;
        }

        public virtual ReturnedResponse<TripCollocationDto> AddWorkTrip(Worktrip worktrip)
        {
            string searchId = GetWorktripSearchId(worktrip);

            Worktrip wtExists = FirstLogic.Select(m => m.Idaccount == worktrip.Idaccount && m.Searchid == searchId).FirstOrDefault();

            if (wtExists != null)
            {
                return AssociationMapDataSubService.GetTripCollocation(wtExists.Idaccount, searchId);
            }

            worktrip.Searchid = searchId;

            Worktrip wt = FirstLogic.Insert(worktrip);

            Collocate(wt.Idaccount, searchId);
            
            return AssociationMapDataSubService.GetTripCollocation(wt.Idaccount, searchId);
        }

        public virtual ReturnedResponse<TripCollocationDto> GetUserAssociations(int accountId, string searchId)
        {
            return AssociationMapDataSubService.GetTripCollocation(accountId, searchId);
        }

        public virtual ReturnedResponse<TripCollocationDto> CollocateAndMatch(int accountId, string searchId)
        {
            Collocate(accountId, searchId);

            return AssociationMapDataSubService.GetTripCollocation(accountId, searchId);
        }

        protected virtual string GetWorktripSearchId(Worktrip workTrip)
        {
            return HashGenerator.Md5(string.Format("AccountId: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                workTrip.Idaccount, workTrip.Longitudefrom, workTrip.Latitudefrom, workTrip.Longitudeto, workTrip.Latitudeto, 
                workTrip.Fromhour.Value.Hour, workTrip.Tohour.Value.Hour, workTrip.Acceptabledistance));
        }
    }
}
