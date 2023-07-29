using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Social.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Social.Bll.Pontiac.Interfaces;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Bll.Pontiac
{
    public class ExpensesService : IExpensesService
    {
        protected IExpenseLogic ExpenseLogic;

        public ExpensesService(IExpenseLogic expenseLogic)
        {
            ExpenseLogic = expenseLogic;
        }

        public virtual ReturnedResponse<Expense> AddExpense(Expense expense)
        {
            Expense expExists = ExpenseLogic.Select(m => m.Idaccount == expense.Idaccount && m.Kind == expense.Kind).FirstOrDefault();

            if (expExists != null)
            {
                ExpenseLogic.Update(expense);

                return new ReturnedResponse<Expense>(expense, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
            }

            return new ReturnedResponse<Expense>(ExpenseLogic.Insert(expense), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
