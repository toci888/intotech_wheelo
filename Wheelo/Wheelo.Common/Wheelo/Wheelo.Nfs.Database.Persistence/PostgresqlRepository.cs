using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheelo.MortalCombat.Database;
using Wheelo.Nfs.Database.Persistence.Models;

namespace Wheelo.Nfs.Database.Persistence
{
    public class PostgresqlRepository<TModel> : FilteringRepository<TModel> where TModel : class
    {
        public PostgresqlRepository()
        {
            DbContext = new wheeloContext();
        }
        public override bool Delete(TModel model)
        {
            throw new NotImplementedException();
        }

        /*public override IQueryable<TModel> Select()
        {
            return null;
            //throw new NotImplementedException();
        }*/

        public override TModel Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}