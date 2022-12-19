using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.ModelMappers.ModelToDtoMaps;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices
{
    public interface IAssociationMapDataSubService
    {
        ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId, string searchId);

        ReturnedResponse<VCollocationsGeoLocationModelDto> GetCollocationUser(int accountId);
    }
}
