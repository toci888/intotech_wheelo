using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite;

namespace Intotech.Warrior
{
    [TsClass(Name = "Dummy", Module = "Intotech.Warrior.Dummy")]
    public class Dummy
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public List<int> GroupMembers { get; set; }
    }
}
