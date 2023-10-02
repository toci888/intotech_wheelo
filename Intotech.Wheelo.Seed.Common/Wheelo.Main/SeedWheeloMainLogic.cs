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
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Database;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Main
{
    public abstract class SeedWheeloMainLogic<TModel> : SeedBase<TModel> where TModel : ModelBase
    {
        public SeedWheeloMainLogic()
        {
            DbHandle = new DbHandleCriticalSectionIW<TModel>(new IntotechWheeloContext(), "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        }
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloContext();
        }
    }
}
