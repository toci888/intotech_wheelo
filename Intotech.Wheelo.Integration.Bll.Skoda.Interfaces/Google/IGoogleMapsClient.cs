using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google
{
    public interface IGoogleMapsClient<TRequest, TResponse> : IGoogleMapsClientBase
    {
        TResponse CallMapApi(TRequest request);
    }
}
