using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface ICollocator<TWorktripLogic, TAccountsCollocationsLogic>
        where TWorktripLogic : IWorkTripLogic
        where TAccountsCollocationsLogic : IUsersCollocationLogic
    {
        List<Vaccountscollocation> Collocate(int accountId);

        List<Vaccountscollocation> AddWorkTrip(Worktrip worktrip);

        List<Vaccountscollocation> GetUserAssociations(int accountId);
    }
}
