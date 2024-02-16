using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Seed.Common.Wheelo.Dictionaries
{
    public class DictionariesSeedManager
    {
        public void SeedAllDb()
        {
            new CarsXmlParser().Insert();
            new CarsModelsParser().Insert();
        }
    }
}
