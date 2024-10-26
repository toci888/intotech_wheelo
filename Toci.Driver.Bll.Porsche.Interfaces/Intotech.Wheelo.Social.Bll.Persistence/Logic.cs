using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Database;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Social.Bll.Persistence
{
    public class Logic<TModel> : LogicBaseCs<TModel> where TModel : ModelBase
    {
        public Logic() : base(true)
        {
            DbHandle = new DbHandleCriticalSectionIW<TModel>(null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        }
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloSocialContext();
        }
    }
}
