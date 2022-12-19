﻿using Intotech.Wheelo.Bll.Models.TripCollocation;
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
using Intotech.Common;
using System.Globalization;
using Intotech.Wheelo.Bll.Persistence.Extensions;

namespace Intotech.Wheelo.Bll.Porsche.WorkTripAssociating
{
    public class WorkTripGenAssociationService : IWorkTripGenAssociationService
    {
        private const double DistanceDivisor = 100000; // todo make sure about this
        private const int MinutesInterval = 15;
        private const int DistanceNormalize = 1000;

        protected IWorktripgenLogic WorktripGenLogic;
        protected IVaworktripgengeolocationLogic VaworktripgengeolocationLogic; // distinct
        protected IVacollocationsgeolocationLogic VacollocationsgeolocationLogic; //accounts collocated, full data
        protected IAccountscollocationLogic AccountscollocationLogic; // an int map
        protected IAssociationCalculations AssociationCalculation;
        protected IVacollocationsgeolocationToAccountCollocationDto ToAccountCollocationDto;
        protected IFriendLogic FriendLogic;
        protected IWorkTripLogic WorkTripHistoryLogic;

        public WorkTripGenAssociationService(IWorktripgenLogic worktripgenLogic, 
            IVaworktripgengeolocationLogic vaworktripgengeolocationLogic,
            IVacollocationsgeolocationLogic vaccountscollocationsworktripLogic,
            IAccountscollocationLogic accountscollocationLogic,
            IAssociationCalculations associationCalculations,
            IVacollocationsgeolocationToAccountCollocationDto toAccountCollocationDto,
            IFriendLogic friendLogic,
            IWorkTripLogic workTripHistoryLogic)
        {
            WorktripGenLogic = worktripgenLogic;
            VaworktripgengeolocationLogic = vaworktripgengeolocationLogic;
            VacollocationsgeolocationLogic = vaccountscollocationsworktripLogic;
            AccountscollocationLogic = accountscollocationLogic;
            AssociationCalculation = associationCalculations;
            ToAccountCollocationDto = toAccountCollocationDto;
            FriendLogic = friendLogic;
            WorkTripHistoryLogic = workTripHistoryLogic;
        }

        public virtual ReturnedResponse<TripGenCollocationDto> SetWorkTripGetCollocations(WorkTripGenDto workTripGen)
        {
            Worktripgen workTripGenRecord = MapWorkTrip(workTripGen);

            List<Worktripgen> workTrips  = WorktripGenLogic.Select(m => m.Idaccount == workTripGen.Idaccount).ToList();

            if (workTrips.Count() > 0)
            {
                StoreHistoryDataWorkTrip(workTrips);
            }
            
            workTripGenRecord = WorktripGenLogic.Insert(workTripGenRecord);
            
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

            resultDto.SourceAccount = ToAccountCollocationDto.Map(collocationSource);

            List<Vacollocationsgeolocation> data = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).ToList();

            resultDto.AccountsCollocated = new List<AccountCollocationDto>();

            foreach (Vacollocationsgeolocation item in data)
            {
                AccountCollocationDto element = ToAccountCollocationDto.Map(item);

                element.AreFriends = FriendLogic.AreFriends(accountId, element.idAccount);

                resultDto.AccountsCollocated.Add(element);
            }

            return new ReturnedResponse<TripGenCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId, int associatedAccountId)
        {
            // TODO potential swap

            Vacollocationsgeolocation data = VacollocationsgeolocationLogic.Select(m => m.Idaccount == sourceAccountId && m.Accountidcollocated == associatedAccountId).FirstOrDefault();

            if (data == null)
            {
                return new ReturnedResponse<AccountCollocationDto>(null, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            AccountCollocationDto resultDto = ToAccountCollocationDto.Map(data);

            resultDto.AreFriends = FriendLogic.AreFriends(sourceAccountId, associatedAccountId);

            return new ReturnedResponse<AccountCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        protected virtual void Collocate(Worktripgen workTripGenRecord)
        {
            double distance = workTripGenRecord.Acceptabledistance.Value / DistanceDivisor;

            List<Worktripgen> collocations = WorktripGenLogic.Select(worktrip => worktrip.Idaccount != workTripGenRecord.Idaccount &&
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

            if (workTripGen.Idaccount > WorktripgenLogic.AccountIdOffset)
            {
                result.Isuser = true;
            }

            string[] FromTime = workTripGen.StartLocationTime.Split(":");
            string[] ToTime = workTripGen.EndLocationTime.Split(":");

            result.Streetfrom = workTripGen.StartLocation.address.road;
            result.Streetto = workTripGen.EndLocation.address.road;
            result.Cityfrom = workTripGen.StartLocation.address.city;
            result.Cityto = workTripGen.EndLocation.address.city;
            result.Postcodefrom = workTripGen.StartLocation.address.postcode;
            result.Postcodeto = workTripGen.EndLocation.address.postcode;
            result.Acceptabledistance = workTripGen.AcceptableDistance;
            result.Fromhour = new TimeOnly(int.Parse(FromTime[0]), int.Parse(FromTime[1]));
            result.Tohour = new TimeOnly(int.Parse(ToTime[0]), int.Parse(ToTime[1]));
            result.Idaccount = workTripGen.Idaccount;
            result.Latitudefrom = double.Parse(workTripGen.StartLocation.lat, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Latitudeto = double.Parse(workTripGen.EndLocation.lat, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Longitudefrom = double.Parse(workTripGen.StartLocation.lon, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Longitudeto = double.Parse(workTripGen.EndLocation.lon, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Searchid = WorktripgenLogic.GetWorktripSearchId(result);
            result.Driverpassenger = workTripGen.IsDriver;

            return result;
        }

        protected virtual int StoreHistoryDataWorkTrip(List<Worktripgen> workTrips)
        {
            foreach (Worktripgen worktripgenRecord in workTrips)
            {
                Worktrip worktripHistoryRecord = DtoModelMapper.Map<Worktrip, Worktripgen>(worktripgenRecord);

                WorkTripHistoryLogic.Insert(worktripHistoryRecord);

                WorktripGenLogic.Delete(worktripgenRecord);
            }

            return workTrips.Count();
        }
    }
}
