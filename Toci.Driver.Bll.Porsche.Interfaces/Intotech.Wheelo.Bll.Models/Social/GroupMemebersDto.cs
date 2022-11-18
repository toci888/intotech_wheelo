using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Social
{
    public class GroupMemebersDto 
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public List<Account> GroupMembers { get; set; }
    }
}
