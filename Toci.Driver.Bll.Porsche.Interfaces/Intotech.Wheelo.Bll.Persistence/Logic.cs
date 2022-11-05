using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll;
using Toci.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{
    public abstract class Logic<TModel> : LogicBase<TModel> where TModel : class
    {
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloContext();
        }
    }
}
