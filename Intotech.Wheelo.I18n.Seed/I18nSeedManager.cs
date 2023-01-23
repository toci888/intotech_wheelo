using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.I18n.Seed
{
    public class I18nSeedManager
    {
        public void SeedAllDb()
        {
            new SeedTags().Insert();
        }
    }
}
