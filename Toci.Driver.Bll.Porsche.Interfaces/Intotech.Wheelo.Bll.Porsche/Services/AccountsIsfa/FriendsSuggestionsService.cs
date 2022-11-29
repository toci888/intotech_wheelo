using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa
{
    public class FriendsSuggestionsService : IFriendsSuggestionsService
    {
        protected IVfriendSuggestionLogic VfriendSuggestionLogic;

        public FriendsSuggestionsService(IVfriendSuggestionLogic vfriendSuggestionLogic)
        {
            VfriendSuggestionLogic = vfriendSuggestionLogic;
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId)
        {
            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Accountid == accountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true);
        }
    }
}
