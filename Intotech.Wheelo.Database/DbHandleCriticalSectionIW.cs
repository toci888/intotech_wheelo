using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Database
{
    public class DbHandleCriticalSectionIW<TModel> : DbHandleCriticalSection<TModel>, IDbHandle<TModel>, IDisposable where TModel : ModelBase
    {
        public DbHandleCriticalSectionIW(Func<DbContext> databaseHandle, string connectionString) : base(databaseHandle, connectionString)
        {
        }

        public override TModel Update(TModel model)
        {
            //DbContext context = FDatabaseHandle();
            //DbContext context = FDatabaseHandle();
            using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                context.Update(model);

                context.SaveChanges();

                //  DatabaseHandle?.Dispose();

                return model;
            }

        }

        public override IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
        {
            using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                IEnumerable<TModel> result = context.Set<TModel>().Where(filter).ToList();

                //context.Dispose();

                return result;
            }
        }

        public override TModel Insert(TModel model)
        {
            //

            // insert into product (id, ....) 
            using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                EntityEntry entr = context.Set<TModel>().Add(model);

                context.SaveChanges();// here

                // DatabaseHandle?.Dispose();

                return (TModel)(entr.Entity);
            }

        }

        public override int Delete(TModel model)
        {
                using (IntotechWheeloContext context = new IntotechWheeloContext())
                {
                    try
                    {
                        TModel element = Select(m => m.Id == model.Id).FirstOrDefault();
                        if (element == null)
                        {
                            return 0;
                        }
                        context.Remove(element);// HERE TO FIX
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }

                    // DatabaseHandle?.Dispose();

                    return 1;
                }
            
        }
    }
}
