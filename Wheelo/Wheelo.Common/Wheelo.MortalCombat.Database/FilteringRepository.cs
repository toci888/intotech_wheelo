using System.Collections.Generic;
using System.Linq;
using System;

namespace Wheelo.MortalCombat.Database
{
    public class FilteringRepository<TModel> : Repository<TModel> where TModel : class
    {


        public virtual IEnumerable<TModel> filterWhere(Func<TModel, bool> whereCriteria)
        {
            return Select().Where(whereCriteria);
        }


    }
}