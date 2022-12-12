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
        public virtual AccountCollocationDto Map(Vacollocationsgeolocation dbModel)
        {
            AccountCollocationDto result = new AccountCollocationDto()
            {
                Accountid = dbModel.Accountidcollocated.Value,
                Latitudefrom = dbModel.Latitudefrom.Value,
                Latitudeto = dbModel.Latitudeto.Value,
                Longitudefrom = dbModel.Longitudefrom.Value,
                Longitudeto = dbModel.Longitudeto.Value,
                Fromhour = dbModel.Fromhour.Value.Hour.ToString() + ":" + dbModel.Fromhour.Value.Minute.ToString(),
                Tohour = dbModel.Tohour.Value.Hour.ToString() + ":" + dbModel.Tohour.Value.Minute.ToString(),
                Name = dbModel.Name,
                Surname = dbModel.Surname
            };

            return result;
        }
    }
}
