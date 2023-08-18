using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.OldModels
{
    public class ResetPasswordConfirmDto  :DtoEntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Code { get; set; }
    }
}
