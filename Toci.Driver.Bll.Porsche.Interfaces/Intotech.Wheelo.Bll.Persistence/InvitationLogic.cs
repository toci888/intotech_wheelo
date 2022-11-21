using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{

    /*
    create or replace view VInvitations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from Invitations 
join Accounts U1 on U1.Id = Invitations.IdAccount 
join Accounts U2 on U2.Id = Invitations.IdInvited ; */

    public class InvitationLogic : Logic<Invitation>, IInvitationLogic
    {
        
    }
}
