using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Isfa
{
    public class MakeFriendSuggestionDto
    {
        public int SuggestingAccountId { get; set; }

        public int SuggestedAccountId { get; set; }

        public int SuggestedAccountFriendId { get; set; }
    }
}
