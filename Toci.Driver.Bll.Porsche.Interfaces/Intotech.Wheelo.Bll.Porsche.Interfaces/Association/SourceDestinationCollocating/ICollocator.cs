using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ICollocator<TWorktripLogic, TAccountsCollocationsLogic>
        where TWorktripLogic : IWorkTripLogic
        where TAccountsCollocationsLogic : IUsersCollocationLogic
    {
        void Collocate(int accountId);
    }
}
