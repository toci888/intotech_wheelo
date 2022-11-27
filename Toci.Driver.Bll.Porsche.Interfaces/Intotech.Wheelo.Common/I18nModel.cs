using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public class I18nModel : II18nModel
    {
        public string Language { get;set; }
        public string Tag { get;set; }
        public string Content { get;set; }
    }
}
