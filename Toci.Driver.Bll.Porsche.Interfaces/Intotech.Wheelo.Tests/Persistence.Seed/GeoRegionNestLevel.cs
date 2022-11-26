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
            SeedRegions();

            /*Geographicregion geographicregion = Select(m => m.Idparent == null).First();

            geographicregion.Nestlevel = 1;

            Update(geographicregion);
            */

        }

        protected void SeedRegions()
        {
            string content = File.ReadAllText("../../../../../SQL/geog_azg.txt");

            List<string> regionsLines = content.Split("\r\n", StringSplitOptions.None).ToList();

            foreach (string line in regionsLines)
            {
                string[] region = line.Split("\t");

                if (region.Length == 4)
                {
                    Insert(new Geographicregion() { Id = int.Parse(region[0]), Idparent = int.Parse(region[1]), Idshit = int.Parse(region[2]), Name = region[3] });
                }
            }
        }
    }
}
