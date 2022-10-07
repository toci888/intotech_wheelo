using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wheelo.MortalCombat.Database.Interfaces;

namespace Wheelo.MortalCombat.Database
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected DbContext DbContext;

        public virtual bool Delete(TModel model)
        {
            EntityEntry entry = DbContext.Remove(model);
            return DbContext.SaveChanges() > 0;
        }

        public virtual TModel Insert(TModel model)
        {
            EntityEntry entry = DbContext.Add(model);
            DbContext.SaveChanges();

            return (TModel)entry.Entity;
        }

        public virtual TModel Update(TModel model)
        {
            EntityEntry entry = DbContext.Update(model);
            DbContext.SaveChanges();

            return (TModel)entry.Entity;
        }
        public virtual IQueryable<TModel> Select()
        {

            return DbContext.Set<TModel>().Select(p => p);

        }
    }
}