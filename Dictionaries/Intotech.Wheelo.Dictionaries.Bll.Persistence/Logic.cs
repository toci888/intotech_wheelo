using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Database;
using Intotech.Wheelo.Dictionaries.Database;
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
    public abstract class Logic<TModel> : LogicBaseCs<TModel> where TModel : ModelBase, new()
    {
        public Logic() : base("Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka")
        {
            DbHandle = new DbHandleCriticalSectionIWD<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        }

        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloDictionariesContext();
        }
    }
}
