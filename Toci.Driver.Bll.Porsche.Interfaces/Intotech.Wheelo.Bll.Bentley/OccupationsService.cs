using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Bentley
{
    public class OccupationsService : IOccupationsService
    {
        protected IOccupationLogic OccupationsLogic;

        public OccupationsService(IOccupationLogic occupationsLogic)
        {
            OccupationsLogic = occupationsLogic;
        }

        public virtual List<Occupation> GetOccupationsForContain(string contain)
        {
            return OccupationsLogic.Select(m => m.Name.Contains(contain)).ToList();
        }
    }
}
