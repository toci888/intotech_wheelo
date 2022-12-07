using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common.Bll.ComplexResponses;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating
{
    public interface IWorkTripGenAssociationService
    {
        ReturnedResponse<TripGenCollocationDto> SetWorkTripGetCollocations(WorkTripGenDto workTripGen);

        ReturnedResponse<TripGenCollocationDto> GetTripCollocation(int accountId, string searchId);
    }
}
