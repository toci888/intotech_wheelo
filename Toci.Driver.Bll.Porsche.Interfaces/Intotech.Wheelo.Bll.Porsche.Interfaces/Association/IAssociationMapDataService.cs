using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association
{
    public interface IAssociationMapDataService
    {
        ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId);
    }
}
