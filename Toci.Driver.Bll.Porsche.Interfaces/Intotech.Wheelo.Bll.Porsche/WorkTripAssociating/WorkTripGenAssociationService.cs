using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;

namespace Intotech.Wheelo.Bll.Porsche.WorkTripAssociating
{
    public class WorkTripGenAssociationService : IWorkTripGenAssociationService
    {
        private const double DistanceDivisor = 100000; // todo make sure about this
        private const int MinutesInterval = 15;
        private const int DistanceNormalize = 1000;

        protected IWorktripgenLogic WorktripLogic;
        protected IVaworktripgengeolocationLogic VaworktripgengeolocationLogic; // distinct
        protected IVacollocationsgeolocationLogic VacollocationsgeolocationLogic;
        protected IAccountscollocationLogic AccountscollocationLogic; // an int map
        protected IAssociationCalculations AssociationCalculation;
        protected IVacollocationsgeolocationToAccountCollocationDto ToAccountCollocationDto;
        protected IFriendLogic FriendLogic;

        public WorkTripGenAssociationService(IWorktripgenLogic worktripgenLogic, 
            IVaworktripgengeolocationLogic vaworktripgengeolocationLogic,
            IVacollocationsgeolocationLogic vaccountscollocationsworktripLogic,
            IAccountscollocationLogic accountscollocationLogic,
            IAssociationCalculations associationCalculations,
            IVacollocationsgeolocationToAccountCollocationDto toAccountCollocationDto,
            IFriendLogic friendLogic)
        {
            WorktripLogic = worktripgenLogic;
            VaworktripgengeolocationLogic = vaworktripgengeolocationLogic;
            VacollocationsgeolocationLogic = vaccountscollocationsworktripLogic;
            AccountscollocationLogic = accountscollocationLogic;
            AssociationCalculation = associationCalculations;
            ToAccountCollocationDto = toAccountCollocationDto;
            FriendLogic = friendLogic;
        }

        public virtual ReturnedResponse<TripGenCollocationDto> SetWorkTripGetCollocations(WorkTripGenDto workTripGen)
        {
            Worktripgen workTripGenRecord = MapWorkTrip(workTripGen);

            List<Worktripgen> workTrips  = WorktripLogic.Select(m => m.Idaccount == workTripGen.AccountId && m.Searchid == workTripGenRecord.Searchid).ToList();

            if (workTrips.Count() > 0)
            {
                if (workTrips.Count() > 1)
                {
                    // ERR !
                }

                // match workTripGenRecord with db -> update ?
            }
            else
            {
                workTripGenRecord = WorktripLogic.Insert(workTripGenRecord);
            }

            Collocate(workTripGenRecord);

            return GetTripCollocation(workTripGenRecord.Idaccount, workTripGenRecord.Searchid);
        }

        public virtual ReturnedResponse<TripGenCollocationDto> GetTripCollocation(int accountId, string searchId)
        {
            TripGenCollocationDto resultDto = new TripGenCollocationDto();

            resultDto.SearchId = searchId;

            //this is implemented distinct in backend
            Vaworktripgengeolocation collocationSource = VaworktripgengeolocationLogic.Select(m => m.Accountid == accountId).FirstOrDefault();

            if (collocationSource == null)
            {
                return new ReturnedResponse<TripGenCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            resultDto.SourceAccount = collocationSource;

            resultDto.AccountsCollocated = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).ToList();

            return new ReturnedResponse<TripGenCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId, int associatedAccountId)
        {
            Vacollocationsgeolocation data = VacollocationsgeolocationLogic.Select(m => m.Idaccount == sourceAccountId && m.Accountidcollocated == associatedAccountId).FirstOrDefault();

            if (data == null)
            {
                return new ReturnedResponse<AccountCollocationDto>(null, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            AccountCollocationDto resultDto = ToAccountCollocationDto.Map(data);

            Friend fr = FriendLogic.Select(m => (m.Idaccount == sourceAccountId && m.Idfriend == associatedAccountId) ||
                (m.Idaccount == associatedAccountId && m.Idfriend == sourceAccountId)).FirstOrDefault();

            resultDto.AreFriends = fr != null;

            return new ReturnedResponse<AccountCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        protected virtual void Collocate(Worktripgen workTripGenRecord)
        {
            double distance = workTripGenRecord.Acceptabledistance.Value / DistanceDivisor;

            List<Worktripgen> collocations = WorktripLogic.Select(worktrip => worktrip.Idaccount != workTripGenRecord.Idaccount &&
                workTripGenRecord.Fromhour.Value.IsBetween(worktrip.Fromhour.Value.AddMinutes(-MinutesInterval), worktrip.Fromhour.Value.AddMinutes(MinutesInterval)) &&
                workTripGenRecord.Tohour.Value.IsBetween(worktrip.Tohour.Value.AddMinutes(-MinutesInterval), worktrip.Tohour.Value.AddMinutes(MinutesInterval)) &&

                (workTripGenRecord.Latitudefrom - distance) <= worktrip.Latitudefrom &&
                (workTripGenRecord.Latitudefrom + distance) >= worktrip.Latitudefrom &&
                (workTripGenRecord.Longitudefrom + distance) >= worktrip.Longitudefrom &&
                (workTripGenRecord.Longitudefrom - distance) <= worktrip.Longitudefrom &&

                (workTripGenRecord.Latitudeto - distance) <= worktrip.Latitudeto &&
                (workTripGenRecord.Latitudeto + distance) >= worktrip.Latitudeto &&
                (workTripGenRecord.Longitudeto + distance) >= worktrip.Longitudeto &&
                (workTripGenRecord.Longitudeto - distance) <= worktrip.Longitudeto
            ).ToList();

    
            foreach (Worktripgen worktrip in collocations)
            {
                if (!IsCollocationDuplicate(workTripGenRecord.Idaccount, worktrip.Idaccount))
                {
                    decimal distanceFrom = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(workTripGenRecord.Latitudefrom,
                        workTripGenRecord.Longitudefrom, worktrip.Latitudefrom, worktrip.Longitudefrom) * DistanceNormalize;

                    decimal distanceTo = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(workTripGenRecord.Latitudeto,
                        workTripGenRecord.Longitudeto, worktrip.Latitudeto, worktrip.Longitudeto) * DistanceNormalize;

                    AccountscollocationLogic.Insert(new Accountscollocation()
                    {
                        Idaccount = workTripGenRecord.Idaccount,
                        Idcollocated = worktrip.Idaccount,
                        Distancefrom = distanceFrom,
                        Distanceto = distanceTo
                    });
                }
            }
        }

        protected virtual bool IsCollocationDuplicate(int accountId, int collocatedAccountId)
        {
            return AccountscollocationLogic.Select(m => m.Idaccount == accountId && 
                m.Idcollocated == collocatedAccountId).FirstOrDefault() != null;
        }

        protected virtual Worktripgen MapWorkTrip(WorkTripGenDto workTripGen)
        {
            Worktripgen result = new Worktripgen();

            if (workTripGen.AccountId > WorktripgenLogic.AccountIdOffset)
            {
                result.Isuser = true;
            }

            result.Streetfrom = workTripGen.StartLocation.address.road;
            result.Streetto = workTripGen.EndLocation.address.road;
            result.Cityfrom = workTripGen.StartLocation.address.city;
            result.Cityto = workTripGen.EndLocation.address.city;
            result.Postcodefrom = workTripGen.StartLocation.address.postcode;
            result.Postcodeto = workTripGen.EndLocation.address.postcode;
            result.Acceptabledistance = workTripGen.AcceptableDistance;
            result.Fromhour = new TimeOnly(workTripGen.StartLocationTime.Hour, workTripGen.StartLocationTime.Minute);
            result.Tohour = new TimeOnly(workTripGen.EndLocationTime.Hour, workTripGen.EndLocationTime.Minute);
            result.Idaccount = workTripGen.AccountId;
            result.Latitudefrom = double.Parse(workTripGen.StartLocation.lat.Replace(".", ","));
            result.Latitudeto = double.Parse(workTripGen.EndLocation.lat.Replace(".", ","));
            result.Longitudefrom = double.Parse(workTripGen.StartLocation.lon.Replace(".", ","));
            result.Longitudeto = double.Parse(workTripGen.EndLocation.lon.Replace(".", ","));
            result.Searchid = WorktripgenLogic.GetWorktripSearchId(result);

            return result;
        }
    }
}
