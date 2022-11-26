using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class GeoRegionNestLevel : SeedLogic<Geographicregion>
    {
        public override void Insert()
        {
            Geographicregion geographicregion = Select(m => m.Idparent == null).First();

            geographicregion.Nestlevel = 1;

            Update(geographicregion);


        }
    }
}
