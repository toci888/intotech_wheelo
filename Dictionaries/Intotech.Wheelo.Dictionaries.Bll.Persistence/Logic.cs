using Intotech.Common.Bll;
using Intotech.Wheelo.Dictionaries.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Dictionaries.Bll.Persistence
{
    public abstract class Logic<TModel> : LogicBase<TModel> where TModel : class, new()
    {
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloDictionariesContext();
        }
    }
}
