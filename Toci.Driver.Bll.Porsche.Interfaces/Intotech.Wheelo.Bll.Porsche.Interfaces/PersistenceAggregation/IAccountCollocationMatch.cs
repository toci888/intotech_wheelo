using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation
{
    public interface IAccountCollocationMatch<TUserLocationLogic, TUsersCollocationLogic> 
        where TUserLocationLogic : IUsersLocationLogic
        where TUsersCollocationLogic : IUsersCollocationLogic
    {
        
        bool TryCollocate(int idUserFirst, int idUserSecond);
    }
}
