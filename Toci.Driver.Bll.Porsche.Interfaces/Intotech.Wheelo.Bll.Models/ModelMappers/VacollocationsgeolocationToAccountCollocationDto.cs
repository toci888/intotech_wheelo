﻿using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Common.ImageService;

namespace Intotech.Wheelo.Bll.Models.ModelMappers
{
    public class VacollocationsgeolocationToAccountCollocationDto : IVacollocationsgeolocationToAccountCollocationDto
    {
        public virtual AccountCollocationDto Map(Vaworktripgengeolocation dbModel)
        {
            AccountCollocationDto result = new AccountCollocationDto()
            {
                idAccount = dbModel.Accountid.Value,
                Latitudefrom = dbModel.Latitudefrom.Value,
                Latitudeto = dbModel.Latitudeto.Value,
                Longitudefrom = dbModel.Longitudefrom.Value,
                Longitudeto = dbModel.Longitudeto.Value,
                Fromhour = dbModel.Fromhour.Value.ToString(), // TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Minute), // 8:0 -> 08:00
                Tohour = dbModel.Tohour.Value.ToString(), // TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Minute),
                Name = dbModel.Name,
                Surname = dbModel.Surname,
                Driver = (Driver)dbModel.Isdriver.Value,
                Image = ImageServiceUtils.GetImageUrl(dbModel.Accountid.Value)
            };

            return result;
        }

        public virtual AccountCollocationDto Map(Vacollocationsgeolocation dbModel, int accountId) 
        {
            int accId = dbModel.Idaccount.Value;
            string name = dbModel.Name;
            string surname = dbModel.Surname;

            if (dbModel.Idaccount.Value == accountId)
            {
                accId = dbModel.Accountidcollocated.Value;
                name = dbModel.Namecollocated;
                surname = dbModel.Surnamecollocated;
            }

            AccountCollocationDto result = new AccountCollocationDto()
            {
                idAccount = accId,
                Latitudefrom = dbModel.Latitudefrom.Value,
                Latitudeto = dbModel.Latitudeto.Value,
                Longitudefrom = dbModel.Longitudefrom.Value,
                Longitudeto = dbModel.Longitudeto.Value,
                Fromhour = dbModel.Fromhour.Value.ToString(),// TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Minute),
                Tohour = dbModel.Tohour.Value.ToString(), //TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Minute),
                Name = name,
                Surname = surname,
                Driver = (Driver)dbModel.Isdriver.Value,
                Image = ImageServiceUtils.GetImageUrl(accId)
            };

            return result;
        }

        public virtual AccountCollocationDto Map(Vcollocationsgeolocation dbModel)
        {
            AccountCollocationDto result = new AccountCollocationDto()
            {
                idAccount = dbModel.Idaccount.Value,
                Latitudefrom = dbModel.Latitudefrom.Value,
                Latitudeto = dbModel.Latitudeto.Value,
                Longitudefrom = dbModel.Longitudefrom.Value,
                Longitudeto = dbModel.Longitudeto.Value,
                Fromhour = dbModel.Fromhour.Value.ToString(), //TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Fromhour.Value.Minute),
                Tohour = dbModel.Tohour.Value.ToString(), //TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Hour) + ":" + TimeUtils.GetCorrectTime(dbModel.Tohour.Value.Minute),
                Name = dbModel.Name,
                Surname = dbModel.Surname,
                Driver = (Driver)dbModel.Driverpassenger.Value,
                Image = ImageServiceUtils.GetImageUrl(dbModel.Idaccount.Value)
            };

            return result;
        }

        public virtual List<AccountCollocationDto> Map(List<Vacollocationsgeolocation> associationsList, int accountId)
        {
            List<AccountCollocationDto> result = new List<AccountCollocationDto>();

            foreach (Vacollocationsgeolocation item in associationsList)
            {
                result.Add(Map(item, accountId));
            }

            return result;
        }
    }
}
