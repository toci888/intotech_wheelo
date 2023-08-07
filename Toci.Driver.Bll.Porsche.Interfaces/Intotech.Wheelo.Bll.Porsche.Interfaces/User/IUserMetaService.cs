using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.OldModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IUserMetaService : IService
    {
        ReturnedResponse<SmokerOccupationDto> SetSmokerOccupation(SmokerOccupationDto smokerOccupationDto);
    }
}
