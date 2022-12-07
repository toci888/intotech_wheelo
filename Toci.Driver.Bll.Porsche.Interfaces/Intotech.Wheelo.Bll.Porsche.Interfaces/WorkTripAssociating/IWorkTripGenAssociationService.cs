using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating
{
    public interface IWorkTripGenAssociationService
    {
        TripGenCollocationDto SetWorkTripGetCollocations(WorkTripGenDto workTripGen);
    }
}
