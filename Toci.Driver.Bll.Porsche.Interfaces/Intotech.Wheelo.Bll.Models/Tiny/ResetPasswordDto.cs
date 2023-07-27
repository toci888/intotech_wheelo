using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Tiny
{
    public class ResetPasswordDto : DtoEntityBase
    {
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
