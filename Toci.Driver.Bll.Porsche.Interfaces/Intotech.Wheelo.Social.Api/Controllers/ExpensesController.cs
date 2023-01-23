using Intotech.Common.Microservices;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Social.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ApiSimpleControllerBase<IExpensesService>
    {
        public ExpensesController(IExpensesService service) : base(service)
        {
        }

        [HttpPost("expense")]
        public Expense AddExpense(Expense exp)
        {
            return Service.AddExpense(exp);
        }
    }
}
