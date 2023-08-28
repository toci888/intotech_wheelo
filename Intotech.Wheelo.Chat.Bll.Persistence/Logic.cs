using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Bll.Persistence
{
    public class Logic<TModel> : LogicBase<TModel> where TModel : ModelBase
    {
        public Logic(bool cs) : base(cs)
        {
            
        }

        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloChatContext();
        }
    }
}
