using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Google
{
    public interface IGoogleMapsClient<TRequest, TResponse>
    {
        TResponse CallGoogleApiPlaceId(TRequest request);
    }
}
