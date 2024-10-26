using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Database
{
    public class DbHandleCriticalSectionIW<TModel> : DbHandleCriticalSection<TModel>, IDbHandle<TModel> where TModel : ModelBase
    {
        private static IntotechWheeloContext intotechWheeloContext;
        private static DbConnection dbConnection;

        public DbHandleCriticalSectionIW(IntotechWheeloContext databaseHandle, string connectionString) : base(null, connectionString)
        {
            if (intotechWheeloContext == null)
            {
                intotechWheeloContext = databaseHandle;
                dbConnection = intotechWheeloContext.Database.GetDbConnection();
                
                //dbConnection.ConnectionString = connectionString;
            }
        }

        public override TModel Update(TModel model)
        {
            //DbContext context = FDatabaseHandle();
            //DbContext context = FDatabaseHandle();
            //using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                //intotechWheeloContext.Database.SetDbConnection(dbConnection);
                //dbConnection.Open();
                intotechWheeloContext.Update(model);

                intotechWheeloContext.SaveChanges();

                //  DatabaseHandle?.Dispose();
                NpgsqlConnection connection = intotechWheeloContext.Database.GetDbConnection() as NpgsqlConnection;

                if (connection != null)
                {
                   // NpgsqlConnection.ClearPool(connection);

                    //connection.Close();
                    // connection.Dispose();
                }

                return model;
            }

        }

        public override IEnumerable<TModel> Select(Expression<Func<TModel, bool>> filter)
        {
            //using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                //intotechWheeloContext.Database.SetDbConnection(dbConnection);
                //dbConnection.Open();

                IEnumerable<TModel> result = intotechWheeloContext.Set<TModel>().Where(filter).ToList();

                //context.Dispose();
                NpgsqlConnection connection = intotechWheeloContext.Database.GetDbConnection() as NpgsqlConnection;

                if (connection != null)
                {
                   // NpgsqlConnection.ClearPool(connection);
                    //connection.Close();
                    // connection.Dispose();
                }

                return result;
            }
        }

        public override TModel Insert(TModel model)
        {
            //

            // insert into product (id, ....) 
            //using (IntotechWheeloContext context = new IntotechWheeloContext())
            {
                //intotechWheeloContext.Database.SetDbConnection(dbConnection);
                //dbConnection.Open();
               
                EntityEntry entr = intotechWheeloContext.Set<TModel>().Add(model);

                intotechWheeloContext.SaveChanges();// here

                // DatabaseHandle?.Dispose();
                NpgsqlConnection connection = intotechWheeloContext.Database.GetDbConnection() as NpgsqlConnection;

                if (connection != null)
                {
                    //NpgsqlConnection.ClearPool(connection);
                    //connection.Close();
                   // connection.Dispose();
                }

                return (TModel)(entr.Entity);
            }

        }

        public override int Delete(TModel model)
        {
                //using (IntotechWheeloContext context = new IntotechWheeloContext())
                
            //intotechWheeloContext.Database.SetDbConnection(dbConnection);
            //dbConnection.Open();
            try
            {
                TModel element = Select(m => m.Id == model.Id).FirstOrDefault();
                if (element == null)
                {
                    return 0;
                }
                intotechWheeloContext.Remove(element);// HERE TO FIX
                intotechWheeloContext.SaveChanges();

                NpgsqlConnection connection = intotechWheeloContext.Database.GetDbConnection() as NpgsqlConnection;

                if (connection != null)
                {
                    //NpgsqlConnection.ClearPool(connection);

                    //connection.Close();
                    // connection.Dispose();
                }
            }
            catch (Exception ex)
            {

            }

            // DatabaseHandle?.Dispose();

            return 1;
                
            
        }
    }
}
