using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Chat.Database;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Bll.Persistence
{
    public class Logic<TModel> : LogicBaseCs<TModel> where TModel : ModelBase
    {
        public Logic() : base(true)
        {
            DbHandle = new DbHandleCriticalSectionIWC<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        }

        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloChatContext(new DbContextOptions<IntotechWheeloChatContext>());
        }
    }
}
