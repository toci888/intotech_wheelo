using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Polly.Caching;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Common.Interfaces.Models;
using System.Security.Principal;
using System.Xml.Linq;
using Npgsql;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTripController : ApiSimpleControllerBase<IWorkTripGenAssociationService>
    {
        public WorkTripController(IWorkTripGenAssociationService logic) : base(logic)
        {
        }

        [HttpPost("add-work-trip")]
        public ReturnedResponse<TripGenCollocationDto> AddWorkTrip([FromBody]WorkTripGenDto workTripGen)
        {
            //var accountsCollocated = new List<AccountCollocationDto>();
            //accountsCollocated.Add(new AccountCollocationDto()
            //{
            //    AreFriends = true,
            //    Fromhour = "08:00",
            //    Tohour = "16:00",
            //    idAccount = 1000000001,
            //    Latitudefrom = 52.400999999999996,
            //    Latitudeto = 51.105,
            //    Longitudefrom = 16.928,
            //    Longitudeto = 17.035,
            //    Name = "Paweł",
            //    PhoneNumber = "123456789",
            //    Surname = "Kowalski",
            //    Driver = Intotech.Wheelo.Common.Interfaces.Models.Driver.both,
            //    Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/7QCEUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAGgcAigAYkZCTUQwYTAwMGE2ZjAxMDAwMGM0MDEwMDAwMmUwMjAwMDA2NjAyMDAwMGEzMDIwMDAwMjMwMzAwMDA5MTAzMDAwMGMxMDMwMDAwZjgwMzAwMDAzNzA0MDAwMGUxMDQwMDAwAP/bAEMABgQFBgUEBgYFBgcHBggKEAoKCQkKFA4PDBAXFBgYFxQWFhodJR8aGyMcFhYgLCAjJicpKikZHy0wLSgwJSgpKP/bAEMBBwcHCggKEwoKEygaFhooKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKP/CABEIACgAKAMBIgACEQEDEQH/xAAbAAACAgMBAAAAAAAAAAAAAAAABgMFAgQHAf/EABkBAAIDAQAAAAAAAAAAAAAAAAECAAMFBP/aAAwDAQACEAMQAAAB6n7gvAskStvw25iFOP2iXE5doUjapv6aUwqoLMDooMQThdgMfX//xAAfEAACAgIDAAMAAAAAAAAAAAABAwIEAAUREhMQFCL/2gAIAQEAAQUC5+ZsEcAMs5BFjYhU7OymJ13p8UPU8KutTOqr7tzYALdRb2NSx52HTyDJQPqe1Cz4uDCSP2y5rQIRBlOrCAySCqH/xAAdEQEAAgEFAQAAAAAAAAAAAAABAAIRAwQQEyEx/9oACAEDAQE/AQzGicCk7MyxAm6s/Jo3bHs//8QAGxEAAwACAwAAAAAAAAAAAAAAAAECAxEEECL/2gAIAQIBAT8BN9UtjkVF00M5eCYryf/EACQQAAICAQMEAgMAAAAAAAAAAAECABESAyExECJBYRNRFIGx/9oACAEBAAY/Auu8tuJfiECiBB8WAT3zPyNVsd638S9Jw0HewXzvFRnXE9xmolA0d5q47gVXqXtj/egdWII4hzJN+4bFo3M7VqKv2amWi/6aBYRQviBn01w+xuJ//8QAIRABAAICAgICAwAAAAAAAAAAAQARITFBUWFxEJGh0fD/2gAIAQEAAT8hA/OzZ6nCnSYWjtZOUGRc1FjAj3fqYdjk7eO5S3+JQ13gYJFt1WaWuDuH3kP8eoSgNAXEId0MUYR6lizIgZjkli7KuzK9rw68xM2uGqlwOL7MfJx/Vw2bWojZByeo7HQvAezif//aAAwDAQACAAMAAAAQ7s9FEMDiC//EABkRAQEBAQEBAAAAAAAAAAAAAAEAESExof/aAAgBAwEBPxBfMWKWRvLIBi3yJHYDl5m/Z23/xAAZEQEBAQEBAQAAAAAAAAAAAAABEQBRITH/2gAIAQIBAT8QWfcFZrgVyFm55gmd8wOmJ13/xAAiEAEAAgICAgIDAQAAAAAAAAABABEhMUFRYXGBkRChwbH/2gAIAQEAAT8Q1Lnpw/kuh8W4yAtrm++o194hrK8JFpUv/INQBrYCtp4SBK6CLgdlPK7rTFJju+T2OSCLgjhyLOpZfJiD+2rjq2PiKcmhaBeFZ+oILidSZQfXGWoaUDkKYSx3n4JZrj/vs4pyPHiDf6bZR3aubhYhaS1jj9sxkO9Kjm7lmM23oP7CXa8Tfof0hgOYOu5pcIC2ll/MdU7DZQ2Ai8Xk9T//2Q=="
            //});

            //TripGenCollocationDto result = new TripGenCollocationDto()
            //{
            //    AccountsCollocated = accountsCollocated,
            //    SearchId = "E8JxN2rY8(p",
            //    SourceAccount = accountsCollocated[0]
            //};

            //return new ReturnedResponse<TripGenCollocationDto>(result, I18nTranslationDep.Translation(I18nTags.Success), true, Intotech.Wheelo.Common.Interfaces.ErrorCodes.Success);
            ReturnedResponse<TripGenCollocationDto> result = Service.SetWorkTripGetCollocations(workTripGen);

            //NpgsqlConnection.ClearAllPools();
            //NpgsqlConnection.ClearPool();

            return result;

        }

        [HttpGet("collocated-account")]
        public ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId, int associatedAccountId)
        {
            return Service.GetAccountDataForMarker(sourceAccountId, associatedAccountId);
        }
        /*
        [HttpPost]
        [Route("add-work-trip")]
        public ReturnedResponse<TripCollocationDto> AddWorkTrip(WorktripDto wt)
        {
            wt.Fromhour = new TimeOnly(wt.IFromHour, wt.IFromMinute);
            wt.Tohour = new TimeOnly(wt.IToHour, wt.IToMinute);

            return Service.AddWorkTrip(wt);
        }*/

        [HttpGet]
        [Route("associated-users")]
        public ReturnedResponse<TripGenCollocationDto> GetAssociatedUsers(int accountId)
        {
            return Service.GetTripCollocation(accountId, string.Empty);
        }
        
    }
}
