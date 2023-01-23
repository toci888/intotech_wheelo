using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Social
{
    public class GroupMemberAddDto : Groupmember
    {
        public string GroupName { get; set; }

        public Toci.Driver.Database.Persistence.Models.Account AddedMember { get; set; }

        public Toci.Driver.Database.Persistence.Models.Account MemberWhoAdded { get; set; }
    }
}
