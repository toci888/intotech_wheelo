using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common.Bll.Seed;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public abstract class SeedWheeloMainLogic<TModel> : SeedBase<TModel> where TModel : class
    {
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloContext();
        }
    }
}
