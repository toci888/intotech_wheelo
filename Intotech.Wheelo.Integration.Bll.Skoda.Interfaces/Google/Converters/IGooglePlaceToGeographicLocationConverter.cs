using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Google.Converters
{
    public interface IGooglePlaceToGeographicLocationConverter<TGooglePlaceModel, TLocationModel>
    {
        TLocationModel Convert(TGooglePlaceModel googlePlaceModel);
    }
}
