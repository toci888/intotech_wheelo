using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace Toci.Driver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountMetadataController : ApiSimpleControllerBase<IAccountMetadataService>
    {
        public AccountMetadataController(IAccountMetadataService logic) : base(logic)
        {
        }

        [HttpPost("account-metadata")]
        public ReturnedResponse<AccountMetadataDto> Create(AccountMetadataDto accountMetaDto)
        {
            return Service.Create(accountMetaDto);
        }

        [HttpPut("account-metadata")]
        public ReturnedResponse<AccountMetadataDto> Update(AccountMetadataDto accountMetaDto)
        {
            return Service.Update(accountMetaDto);
        }
    }
}
