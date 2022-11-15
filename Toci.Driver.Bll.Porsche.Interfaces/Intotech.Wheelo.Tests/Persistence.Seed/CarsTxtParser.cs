using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    [TestClass]
    public class CarsTxtParser
    {
        [TestMethod]
        public virtual List<string> GetCarsBrands()
        {
            List<string> carsBrands = new List<string>();

            // wczytac plik do zmiennej string
            string content = File.ReadAllText("../../../../../SQL/cars.txt");
            // 


            string[] elementsToFurtherSplit = content.Split('\n');

            foreach (string element in elementsToFurtherSplit)
            {
                string[] items = element.Split('-');
                //content.

                carsBrands.Add(items[0]);
            }

            return carsBrands;
        }
    }
}
