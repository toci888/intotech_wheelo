using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Dal.Invitation
{
    public abstract class DalBase<TModel> : IDal<TModel>
    {
        protected DriverEntities WheeloDbContext;

        public DalBase(DriverEntities db)
        {
            WheeloDbContext = db;
        }

       // public abstract IQueryable<TModel> Select(Expression<Func<TModel, bool>> @where);
    }
}