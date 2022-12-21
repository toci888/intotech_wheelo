using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IUserMetaService
    {
        ReturnedResponse<SmokerOccupationDto> SetSmokerOccupation(SmokerOccupationDto smokerOccupationDto);
    }
}
