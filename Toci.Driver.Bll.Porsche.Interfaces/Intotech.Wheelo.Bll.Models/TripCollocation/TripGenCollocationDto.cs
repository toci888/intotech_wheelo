using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.TripCollocation
{
    public class TripGenCollocationDto
    {
        public AccountCollocationDto SourceAccount { get; set; }

        public List<AccountCollocationDto> AccountsCollocated { get; set; } //Vaccountscollocationsworktrip

        public string SearchId { get; set; }
    }
}
