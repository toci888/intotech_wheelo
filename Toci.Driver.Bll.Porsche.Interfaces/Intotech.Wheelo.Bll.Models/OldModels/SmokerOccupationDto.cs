using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.OldModels
{
    public class SmokerOccupationDto : DtoEntityBase
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idoccupation { get; set; }
        public bool Issmoker { get; set; }
    }
}
