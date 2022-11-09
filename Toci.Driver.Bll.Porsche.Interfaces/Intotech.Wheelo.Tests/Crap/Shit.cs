using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Porsche.Association.SourceDestinationCollocating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Crap
{
    [TestClass]
    public class Shit
    {
        [TestMethod]
        public void doopa()
        {
            //double longitude = 50.05463180727613;

            Collocator collocator = new Collocator(new WorkTripLogic(), new UsersCollocationLogic());

            collocator.Collocate(2);

        }
    }
}
