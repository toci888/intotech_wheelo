using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.I18n.Database.Persistence.Models;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.I18n.Seed
{
    public abstract class SeedI18nLogic<TModel> : SeedBase<TModel> where TModel : class
    {
        protected List<TModel> ModelsCollection = new List<TModel>();

        protected override DbContext GetEfHandle()
        {

            return new IntotechWheeloI18nContext();

        }
    }
}
