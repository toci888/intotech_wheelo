using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Intotech.Wheelo.Notifications.Interfaces;
using Intotech.Wheelo.Notifications.Interfaces.Models.DataNotification;
using Intotech.Wheelo.Notifications.Interfaces.Models;
using Npgsql;
using Intotech.Common.Bll;
using Intotech.Common.Interfaces;
using Polly.Caching;

namespace Intotech.Wheelo.Bll.Porsche.WorkTripAssociating
{
    public class WorkTripGenAssociationService : ServiceBaseEx, IWorkTripGenAssociationService
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
        protected IWorktripLogic WorkTripHistoryLogic;
        protected INotificationManager NotificationManager;

        public WorkTripGenAssociationService(IWorktripgenLogic worktripgenLogic, 
            IVaworktripgengeolocationLogic vaworktripgengeolocationLogic,
            IVacollocationsgeolocationLogic vaccountscollocationsworktripLogic,
            IAccountscollocationLogic accountscollocationLogic,
            IAssociationCalculations associationCalculations,
            IVacollocationsgeolocationToAccountCollocationDto toAccountCollocationDto,
            IFriendLogic friendLogic,
            IWorktripLogic workTripHistoryLogic,
            INotificationManager notificationManager,
            ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            WorktripGenLogic = worktripgenLogic;
            VaworktripgengeolocationLogic = vaworktripgengeolocationLogic;
            VacollocationsgeolocationLogic = vaccountscollocationsworktripLogic;
            AccountscollocationLogic = accountscollocationLogic;
            AssociationCalculation = associationCalculations;
            ToAccountCollocationDto = toAccountCollocationDto;
            FriendLogic = friendLogic;
            WorkTripHistoryLogic = workTripHistoryLogic;
            NotificationManager = notificationManager;
        }

        public virtual ReturnedResponse<TripGenCollocationDto> SetWorkTripGetCollocations(WorkTripGenDto entityDto)
        {
            Worktripgen workTripGenRecord = MapWorkTrip(entityDto);

            List<Worktripgen> workTrips  = WorktripGenLogic.Select(m => m.Idaccount == entityDto.Idaccount).ToList();

            if (workTrips.Count() > 0)
            {
                StoreHistoryDataWorkTrip(workTrips);
            }

            WorktripGenLogic.Delete(workTripGenRecord);
            workTripGenRecord = WorktripGenLogic.Insert(workTripGenRecord);

            if (workTripGenRecord == null)
            {
                return new ReturnedResponse<TripGenCollocationDto>(new TripGenCollocationDto(), I18nTranslationDep.Translation(I18nTags.Error), false, ErrorCodes.FailedToAddInformation);
            }

            if (workTripGenRecord.Id < 1)
            {
                workTripGenRecord = WorktripGenLogic.Insert(workTripGenRecord);
            }
            else
            {
                workTripGenRecord = WorktripGenLogic.Update(workTripGenRecord);
            }

            Collocate(workTripGenRecord);

            return GetTripCollocation(workTripGenRecord.Idaccount, workTripGenRecord.Searchid);
        }

        public virtual ReturnedResponse<TripGenCollocationDto> GetTripCollocation(int accountId, string searchId)
        {
            TripGenCollocationDto resultDto = new TripGenCollocationDto();

            resultDto.SearchId = searchId;

            Vaworktripgengeolocation collocationSource = new Vaworktripgengeolocation();
            try
            {
                collocationSource = VaworktripgengeolocationLogic.Select(m => m.Accountid == accountId).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            //this is implemented distinct in backend
            

            if (collocationSource == null)
            {
                return new ReturnedResponse<TripGenCollocationDto>(resultDto, I18nTranslationDep.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            resultDto.SourceAccount = ToAccountCollocationDto.Map(collocationSource);

            List<Vacollocationsgeolocation> data = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId || m.Accountidcollocated == accountId).ToList();

            resultDto.AccountsCollocated = new List<AccountCollocationDto>();

            foreach (Vacollocationsgeolocation item in data)
            {
                AccountCollocationDto element = ToAccountCollocationDto.Map(item, accountId);

                element.AreFriends = FriendLogic.AreFriends(accountId, element.idAccount);

                resultDto.AccountsCollocated.Add(element);
            }

            return new ReturnedResponse<TripGenCollocationDto>(resultDto, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId,
            int associatedAccountId)
        {
            WheeloUtils.PotentialSwapIds(ref sourceAccountId, ref associatedAccountId);

            Vacollocationsgeolocation data = VacollocationsgeolocationLogic
                .Select(m => m.Idaccount == sourceAccountId && m.Accountidcollocated == associatedAccountId)
                .FirstOrDefault();

            if (data == null)
            {
                return new ReturnedResponse<AccountCollocationDto>(null, I18nTranslationDep.Translation(I18nTags.NoData),
                    false, ErrorCodes.NoData);
            }

            AccountCollocationDto resultDto = ToAccountCollocationDto.Map(data, sourceAccountId);

            resultDto.AreFriends = FriendLogic.AreFriends(sourceAccountId, associatedAccountId);

            return new ReturnedResponse<AccountCollocationDto>(resultDto, I18nTranslationDep.Translation(I18nTags.Success),
                true, ErrorCodes.Success);
        }

        protected virtual void Collocate(Worktripgen workTripGenRecord)
        {
            double distance = workTripGenRecord.Acceptabledistance.Value / DistanceDivisor;
            int IsDriverPassenger = CommonConstants.IsPassenger;

            if (workTripGenRecord.Driverpassenger == CommonConstants.IsPassenger)
            {
                IsDriverPassenger = CommonConstants.IsDriver;
            }

            Stopwatch stw = new Stopwatch();
            
            stw.Start();
            string rawSelect = "select * from Worktripgen where idaccount != " + workTripGenRecord.Idaccount + " and Fromhour between '" +
                               workTripGenRecord.Fromhour.Value.AddMinutes(-MinutesInterval) + "' and '" + workTripGenRecord.Fromhour.Value.AddMinutes(MinutesInterval) +
                               "' and Tohour between '" + workTripGenRecord.Tohour.Value.AddMinutes(-MinutesInterval) + "' and '" + 
                               workTripGenRecord.Tohour.Value.AddMinutes(MinutesInterval) + "' and Driverpassenger >= " + IsDriverPassenger +
                               " and Latitudefrom >= " +
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Latitudefrom - distance) + " and Latitudefrom <= " + 
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Latitudefrom + distance) + " and Longitudefrom <= " +
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Longitudefrom + distance) + " and Longitudefrom >= " + 
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Longitudefrom - distance) + " and Latitudeto >= " +
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Latitudeto - distance) + " and Latitudeto <= " + 
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Latitudeto + distance) + " and Longitudeto <= " +
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Longitudeto + distance) + " and Longitudeto >= " + 
                               StringUtils.ReplaceCommaWithDot(workTripGenRecord.Longitudeto - distance) + ";";

            
            List<Worktripgen> collocations = WorktripGenLogic.RawSelect(rawSelect, WorktripGenLogic.MapFromReader).ToList();
            
            long elapsedNpgsql = stw.ElapsedTicks;
            stw.Stop();
            
            /*List<Worktripgen> collocations = WorktripGenLogic.Select(worktrip => worktrip.Idaccount != workTripGenRecord.Idaccount &&
               workTripGenRecord.Fromhour.Value.IsBetween(worktrip.Fromhour.Value.AddMinutes(-MinutesInterval), worktrip.Fromhour.Value.AddMinutes(MinutesInterval)) &&
               workTripGenRecord.Tohour.Value.IsBetween(worktrip.Tohour.Value.AddMinutes(-MinutesInterval), worktrip.Tohour.Value.AddMinutes(MinutesInterval)) &&
                worktrip.Driverpassenger >= IsDriverPassenger &&
                (workTripGenRecord.Latitudefrom - distance) <= worktrip.Latitudefrom &&
                (workTripGenRecord.Latitudefrom + distance) >= worktrip.Latitudefrom &&
                (workTripGenRecord.Longitudefrom + distance) >= worktrip.Longitudefrom &&
                (workTripGenRecord.Longitudefrom - distance) <= worktrip.Longitudefrom &&

                (workTripGenRecord.Latitudeto - distance) <= worktrip.Latitudeto &&
                (workTripGenRecord.Latitudeto + distance) >= worktrip.Latitudeto &&
                (workTripGenRecord.Longitudeto + distance) >= worktrip.Longitudeto &&
                (workTripGenRecord.Longitudeto - distance) <= worktrip.Longitudeto
            ).ToList();*/

            // long elapsedBoth = stw.ElapsedTicks;
            // stw.Stop();

            foreach (Worktripgen worktrip in collocations)
            {
                int accountId = workTripGenRecord.Idaccount;
                int collocatedAccountId = worktrip.Idaccount;

                WheeloUtils.PotentialSwapIds(ref accountId, ref collocatedAccountId);

                
                decimal distanceFrom = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(workTripGenRecord.Latitudefrom,
                    workTripGenRecord.Longitudefrom, worktrip.Latitudefrom, worktrip.Longitudefrom) * DistanceNormalize;

                decimal distanceTo = (decimal)AssociationCalculation.DistanceInKmBetweenEarthCoordinates(workTripGenRecord.Latitudeto,
                    workTripGenRecord.Longitudeto, worktrip.Latitudeto, worktrip.Longitudeto) * DistanceNormalize;

                if (!IsCollocationDuplicate(accountId, collocatedAccountId))
                {
                    AccountscollocationLogic.Insert(new Accountscollocation()
                    {
                        Idaccount = accountId,
                        Idcollocated = collocatedAccountId,
                        Distancefrom = distanceFrom,
                        Distanceto = distanceTo
                    });
                }

                    //NotificationManager.SendNotifications<AssociationNotification>(NotificationsKinds.Association, 
                    //    new NotificationModelBase<AssociationNotification>(new List<string>() { "ExponentPushToken[rtWCLaAF92lqq4mIgmzvRV]", "ExponentPushToken[XqgL8PLm-p-XsCtlZ_dapr]" }, 
                    //    new NotificationDataField<AssociationNotification>() { screen = "SignIn", screenParams = null, root = ""  }, "Asssssocjujemy", "Tytuł jakich mało", "Sub - Zero"));

                    //ScreenParams = new AssociationNotification() { IdAccountAssociated = 100000027 }
                
            }

        }

        protected virtual bool IsCollocationDuplicate(int accountId, int collocatedAccountId)
        {
            return AccountscollocationLogic.Select(m => (m.Idaccount == accountId && 
                m.Idcollocated == collocatedAccountId) || (m.Idaccount == collocatedAccountId && m.Idcollocated == accountId)).FirstOrDefault() != null;
        }

        protected virtual Worktripgen MapWorkTrip(WorkTripGenDto workTripGen)
        {
            Worktripgen result = new Worktripgen();

            string[] FromTime = workTripGen.startLocationTime.Split(":");
            string[] ToTime = workTripGen.endLocationTime.Split(":");

            result.Streetfrom = workTripGen.startLocation.address.road;
            result.Streetto = workTripGen.endLocation.address.road;
            result.Cityfrom = workTripGen.startLocation.address.city;
            result.Cityto = workTripGen.endLocation.address.city;
            result.Postcodefrom = workTripGen.startLocation.address.postcode;
            result.Postcodeto = workTripGen.endLocation.address.postcode;
            result.Acceptabledistance = workTripGen.AcceptableDistance;
            result.Fromhour = new TimeOnly(int.Parse(FromTime[0]), int.Parse(FromTime[1]));
            result.Tohour = new TimeOnly(int.Parse(ToTime[0]), int.Parse(ToTime[1]));
            result.Idaccount = workTripGen.Idaccount;
            result.Latitudefrom = double.Parse(workTripGen.startLocation.lat, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Latitudeto = double.Parse(workTripGen.endLocation.lat, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Longitudefrom = double.Parse(workTripGen.startLocation.lon, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Longitudeto = double.Parse(workTripGen.endLocation.lon, CultureInfo.InvariantCulture); //.Replace(".", ","));
            result.Driverpassenger = workTripGen.DriverPassenger; //1 passenger, 2 driver, 3 both

            return result;
        }

        protected virtual int StoreHistoryDataWorkTrip(List<Worktripgen> workTrips)
        {
            foreach (Worktripgen worktripgenRecord in workTrips)
            {
                Worktrip worktripHistoryRecord = DtoModelMapper.Map<Worktrip, Worktripgen>(worktripgenRecord);

                worktripHistoryRecord.Id = 0;

                WorkTripHistoryLogic.Insert(worktripHistoryRecord);

                int count = AccountscollocationLogic.Delete("Accountcollocations","idaccount = " + worktripgenRecord.Idaccount + " or idcollocated = " + worktripgenRecord.Idaccount);
            }

            return workTrips.Count();
        }
    }
}
