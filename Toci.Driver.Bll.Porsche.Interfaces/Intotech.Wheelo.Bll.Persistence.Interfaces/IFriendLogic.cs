using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.Interfaces;

public interface IFriendLogic : ILogicBase<Friend>
{
    Vfriend AccecptInviteToFriends(int proposalAccountId, int accountId);
}

