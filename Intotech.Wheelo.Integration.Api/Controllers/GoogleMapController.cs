using Intotech.Wheelo.Common.Google;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Integration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleMapController : ControllerBase
    {
        [HttpGet("recognize-place-id")]
        public virtual GeographicLocation GetLocationByPlaceId(string placeId)
        {
            var x = new GoogleService().GetLocationByPlaceId(placeId);
            x.address.name = x.display_name;
            return x;
        }

        [HttpGet("address-autocomplete")]
        public virtual GeographicLocation[] GetAutocompleteHints(string query)
        {
            
            return new GoogleService().GetLocationsByQueryText(query);
        }
    }
}