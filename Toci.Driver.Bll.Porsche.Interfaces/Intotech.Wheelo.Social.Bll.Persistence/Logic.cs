using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Social.Bll.Persistence
{
    public class Logic<TModel> : LogicBase<TModel> where TModel : ModelBase
    {
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloSocialContext();
        }
    }
}
