﻿using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.OldModels
{
    public class EmailConfirmDto : DtoEntityBase
    {
        public string Email { get; set; }
        public int Code { get; set; }
    }
}
