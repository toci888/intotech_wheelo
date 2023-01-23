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

        public virtual Expense AddExpense(Expense expense)
        {
            Expense expExists = ExpenseLogic.Select(m => m.Idaccount == expense.Idaccount && m.Kind == expense.Kind).FirstOrDefault();

            if (expExists != null)
            {
                ExpenseLogic.Update(expense);

                return expense;
            }

            return ExpenseLogic.Insert(expense);
        }
    }
}
