using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class CarsTxtParser
    {
        public virtual List<string> GetCarsBrands(string path)
        {
            List<string> carsBrands = new List<string>();

            // wczytac plik do zmiennej string
            string content = File.ReadAllText(path);
            // 

            string[] elementsToFurtherSplit = content.Split('\n');

            foreach (string element in elementsToFurtherSplit)
            {
                element.Split('-');
                //content.
            }

            return carsBrands;
        }
    }
}
