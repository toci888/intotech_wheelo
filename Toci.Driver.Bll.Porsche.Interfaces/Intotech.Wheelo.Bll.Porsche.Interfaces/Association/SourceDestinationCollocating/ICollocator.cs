using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ICollocator<TWorktripLogic, TAccountsCollocationsLogic>
        where TWorktripLogic : IWorkTripLogic
        where TAccountsCollocationsLogic : IAccountscollocationLogic
    {
        ReturnedResponse<TripCollocationDto> CollocateAndMatch(int accountId, string searchId);

        ReturnedResponse<TripCollocationDto> AddWorkTrip(Worktrip worktrip);

        ReturnedResponse<TripCollocationDto> GetUserAssociations(int accountId, string searchId);
    }
}
