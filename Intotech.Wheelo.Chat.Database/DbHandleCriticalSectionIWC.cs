
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Database
{
        public class DbHandleCriticalSectionIWC<TModel> : DbHandleCriticalSection<TModel>, IDbHandle<TModel> where TModel : ModelBase
        {
            public DbHandleCriticalSectionIWC(Func<DbContext> databaseHandle, string connectionString) : base(databaseHandle(), connectionString)
            {
            }

            public override TModel Update(TModel model)
            {
                //DbContext context = FDatabaseHandle();
                //DbContext context = FDatabaseHandle();
                using (IntotechWheeloChatContext context = new IntotechWheeloChatContext())
                {
                    context.Update(model);

                    context.SaveChanges();

                    //  DatabaseHandle?.Dispose();

                    return model;
                }

            }

            public override IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
            {
                using (IntotechWheeloChatContext context = new IntotechWheeloChatContext())
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
                using (IntotechWheeloChatContext context = new IntotechWheeloChatContext())
                {
                    EntityEntry entr = context.Set<TModel>().Add(model);

                    context.SaveChanges();// here

                    // DatabaseHandle?.Dispose();

                    return (TModel)(entr.Entity);
                }

            }

            public override int Delete(TModel model)
            {
                using (IntotechWheeloChatContext context = new IntotechWheeloChatContext())
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

