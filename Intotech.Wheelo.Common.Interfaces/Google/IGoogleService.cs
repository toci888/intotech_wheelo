using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Google
{
    public interface IGoogleService
    {
        GeographicLocation GetLocationByPlaceId(string placeId);

        GeographicLocation[] GetLocationsByQueryText(string query);
    }
}
