using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Account
{
    public class EmailConfirmDto
    {
        public string Email { get; set; }
        public int Code { get; set; }
    }
}
