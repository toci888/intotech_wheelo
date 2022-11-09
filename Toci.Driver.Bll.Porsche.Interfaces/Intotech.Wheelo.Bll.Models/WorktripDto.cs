using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models
{
    public class WorktripDto : Worktrip
    {
        public int IFromHour { get; set; }
        public int IToHour { get; set; }
        public int IFromMinute { get; set; }
        public int IToMinute { get; set; }
    }
}
