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
        [Route("get-user-account")]
        public Accountrole GetUserAccount(int accountId)
        {
            return Logic.GetUserAccounts(accountId);
        }
    }
}
