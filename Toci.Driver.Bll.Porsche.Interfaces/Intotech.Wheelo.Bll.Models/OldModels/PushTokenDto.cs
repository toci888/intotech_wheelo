using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.OldModels
{
    public class PushTokenDto : DtoEntityBase
    {
        //public int Id { get; set; }
       // public int Idaccount { get; set; }

        public string Op { get; set; }
        public string Token { get; set; } = null!;
      //  public DateTime Createdat { get; set; }
    }
}
