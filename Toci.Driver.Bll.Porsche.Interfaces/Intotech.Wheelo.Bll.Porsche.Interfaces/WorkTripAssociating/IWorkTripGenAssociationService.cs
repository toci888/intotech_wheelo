using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating
{
    public interface IWorkTripGenAssociationService : IService
    {
        ReturnedResponse<TripGenCollocationDto> SetWorkTripGetCollocations(WorkTripGenDto workTripGen);

        ReturnedResponse<TripGenCollocationDto> GetTripCollocation(int accountId, string searchId);

        ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId, int associatedAccountId);
    }
}
