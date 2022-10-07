using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wheelo.MortalCombat.Database.Interfaces
{
    public interface IRepository<TModel> 
    {
        IQueryable<TModel> Select();

        TModel Insert(TModel model);

        bool Delete(TModel model);
    }
}
