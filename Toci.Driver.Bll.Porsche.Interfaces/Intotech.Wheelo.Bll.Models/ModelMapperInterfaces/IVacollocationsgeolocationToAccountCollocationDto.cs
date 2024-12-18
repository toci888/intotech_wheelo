﻿using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces
{ 
    public interface IVacollocationsgeolocationToAccountCollocationDto : IAccountIsfaToDto<Vacollocationsgeolocation, AccountCollocationDto>
    {
        AccountCollocationDto Map(Vcollocationsgeolocation dbModel);
        AccountCollocationDto Map(Vaworktripgengeolocation dbModel);
    }
}
