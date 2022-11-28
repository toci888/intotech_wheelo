using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Social.Bll.Lamborgini.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Social.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ApiSimpleControllerBase<IAccountBll>
    {
        public AccountsController(IAccountBll logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("user-account")]
        public ReturnedResponse<Accountrole> GetUserAccount(int accountId)
        {
            return Logic.GetUserAccounts(accountId);
        }
    }
}
