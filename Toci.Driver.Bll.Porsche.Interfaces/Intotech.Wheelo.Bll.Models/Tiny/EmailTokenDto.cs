﻿using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Tiny
{
    public class EmailTokenDto : DtoEntityBase
    {
        public string email { get; set; }  
        public string token { get; set; }
    }
}
