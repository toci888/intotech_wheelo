using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Account
{
    public class TokensModel
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
