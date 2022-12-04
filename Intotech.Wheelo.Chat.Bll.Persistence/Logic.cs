using Intotech.Common.Bll;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Bll.Persistence
{
    public class Logic<TModel> : LogicBase<TModel> where TModel : class
    {
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloChatContext();
        }
    }
}
