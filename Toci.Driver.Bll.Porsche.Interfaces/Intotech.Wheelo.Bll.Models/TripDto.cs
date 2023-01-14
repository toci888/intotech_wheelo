using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models
{
    public class TripDto
    {
        public List<int> AccountIds { get; set; }
        public int Id { get; set; }
        public int Idinitiatoraccount { get; set; }
        public int Idworktrip { get; set; }
        public DateOnly? Tripdate { get; set; }
        public bool? Iscurrent { get; set; }
        public TimeOnly? Fromhour { get; set; }
        public TimeOnly? Tohour { get; set; }
        public string? Summary { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Leftseats { get; set; }
    }
}
