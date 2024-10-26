﻿using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Database;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class Logic<TModel> : LogicBaseCs<TModel> where TModel : ModelBase
    {
        public Logic() : base(true)
        {
            DbHandle = new DbHandleCriticalSectionIW<TModel>(new IntotechWheeloContext(), "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        }
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloContext();
        }
    }
}
