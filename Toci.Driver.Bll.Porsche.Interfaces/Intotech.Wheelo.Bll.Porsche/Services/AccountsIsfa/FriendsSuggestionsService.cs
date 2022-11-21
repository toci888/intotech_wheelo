using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
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

        public virtual List<Vfriendsuggestion> GetSuggestions(int accountId)
        {
            return VfriendSuggestionLogic.Select(m => m.Accountid == accountId).ToList();
        }
    }
}
