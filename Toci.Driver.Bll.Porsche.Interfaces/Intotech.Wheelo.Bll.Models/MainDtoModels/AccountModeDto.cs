using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.MainDtoModels
{
    public class AccountModeDto : DtoEntityBase
    {
        public int AccountId { get; set; }
        public bool Mode { get; set; }
    }
}
