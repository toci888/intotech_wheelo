using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.Isfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa
{
    public interface IFriendsSuggestionsService : IService
    {
        ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId);

        ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId);

        ReturnedResponse<List<Vfriendsuggestion>> MakeSuggestion(MakeFriendSuggestionDto friendSuggestionDto);
    }
}
