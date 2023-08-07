using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Integration.Bll.Skoda.Interfaces.Services
{
    public interface IGoogleMapsService : IService
    {
        GeographicLocation GetLocationByPlaceId(string placeId);

        GeographicLocation[] GetLocationsByQueryText(string query);

        GeographicLocation GetCurrentButtonLocation(string latitue, string longitude);
    }
}
