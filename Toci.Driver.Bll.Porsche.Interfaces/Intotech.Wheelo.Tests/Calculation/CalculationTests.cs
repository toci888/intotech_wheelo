using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Association;

namespace Intotech.Wheelo.Tests.Calculation
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void test()
        {
            AssociationCalculations ac = new AssociationCalculations();

            ac.DistanceInKmBetweenEarthCoordinates(52.22652535393791, 21.083972711416152, 52.227426306512584, 21.093454499364036);
        }
    }
}
