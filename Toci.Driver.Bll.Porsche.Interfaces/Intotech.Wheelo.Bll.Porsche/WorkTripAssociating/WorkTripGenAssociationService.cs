using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Common.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.WorkTripAssociating
{
    public class WorkTripGenAssociationService : IWorkTripGenAssociationService
    {


        public virtual TripGenCollocationDto SetWorkTripGetCollocations(WorkTripGenDto workTripGen)
        {
            throw new NotImplementedException();
        }

        protected virtual Worktripgen MapWorkTrip(WorkTripGenDto workTripGen)
        {
            Worktripgen result = new Worktripgen();

            result.Streetfrom = workTripGen.StartLocation.address.road;
            result.Streetto = workTripGen.EndLocation.address.road;
            result.Cityfrom = workTripGen.StartLocation.address.city;
            result.Cityto = workTripGen.EndLocation.address.city;
            result.Postcodefrom = workTripGen.StartLocation.address.postcode;
            result.Postcodeto = workTripGen.EndLocation.address.postcode;
            result.Acceptabledistance = workTripGen.AcceptableDistance;
            result.Fromhour = workTripGen.StartLocationTime;
            result.Tohour = workTripGen.EndLocationTime;
            result.Idaccount = workTripGen.AccountId;
            result.Latitudefrom = double.Parse(workTripGen.StartLocation.lat);
            result.Latitudeto = double.Parse(workTripGen.EndLocation.lat);
            result.Longitudefrom = double.Parse(workTripGen.StartLocation.lon);
            result.Longitudeto = double.Parse(workTripGen.EndLocation.lon);

            return result;
        }
    }
}
