using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Bll.Pontiac.Interfaces
{
    public interface IExpensesService
    {
        //refactor to use returnedresponse<>

        ReturnedResponse<Expense> AddExpense(Expense expense);
    }
}
