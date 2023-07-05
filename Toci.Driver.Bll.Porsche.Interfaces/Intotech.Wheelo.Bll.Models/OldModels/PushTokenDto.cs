using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Account
{
    public class PushTokenDto
    {
        //public int Id { get; set; }
       // public int Idaccount { get; set; }

        public string Op { get; set; }
        public string Token { get; set; } = null!;
      //  public DateTime Createdat { get; set; }
    }
}
