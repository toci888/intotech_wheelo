using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa
{
    public interface IFriendsService
    {
        ReturnedResponse<List<FriendsDto>> GetVfriends(int accountId);

        ReturnedResponse<Vfriend> AddFriend(NewFriendAddDto friend);

        ReturnedResponse<bool> Unfriend(int accountId, int idFriendToRemove);
    }
}
