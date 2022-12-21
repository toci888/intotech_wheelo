using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

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
                Fromhour = dbModel.Fromhour.Value.Hour.ToString() + ":" + dbModel.Fromhour.Value.Minute.ToString(),
                Tohour = dbModel.Tohour.Value.Hour.ToString() + ":" + dbModel.Tohour.Value.Minute.ToString(),
                Name = dbModel.Name,
                Surname = dbModel.Surname,
                Driver = (Driver)dbModel.Isdriver.Value,
                Image = dbModel.Image
            };

            return result;
        }

        public virtual AccountCollocationDto Map(Vacollocationsgeolocation dbModel) 
        {
            AccountCollocationDto result = new AccountCollocationDto()
            {
                idAccount = dbModel.Accountidcollocated.Value,
                Latitudefrom = dbModel.Latitudefrom.Value,
                Latitudeto = dbModel.Latitudeto.Value,
                Longitudefrom = dbModel.Longitudefrom.Value,
                Longitudeto = dbModel.Longitudeto.Value,
                Fromhour = dbModel.Fromhour.Value.Hour.ToString() + ":" + dbModel.Fromhour.Value.Minute.ToString(),
                Tohour = dbModel.Tohour.Value.Hour.ToString() + ":" + dbModel.Tohour.Value.Minute.ToString(),
                Name = dbModel.Name,
                Surname = dbModel.Surname,
                Driver = (Driver)dbModel.Isdriver.Value,
                Image = dbModel.Image
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
                Fromhour = dbModel.Fromhour.Value.Hour.ToString() + ":" + dbModel.Fromhour.Value.Minute.ToString(),
                Tohour = dbModel.Tohour.Value.Hour.ToString() + ":" + dbModel.Tohour.Value.Minute.ToString(),
                Name = dbModel.Name,
                Surname = dbModel.Surname,
                Driver = (Driver)dbModel.Driverpassenger.Value,
                Image = dbModel.Image
            };

            return result;
        }

        public virtual List<AccountCollocationDto> Map(List<Vacollocationsgeolocation> associationsList)
        {
            List<AccountCollocationDto> result = new List<AccountCollocationDto>();

            foreach (Vacollocationsgeolocation item in associationsList)
            {
                result.Add(Map(item));
            }

            return result;
        }
    }
}
