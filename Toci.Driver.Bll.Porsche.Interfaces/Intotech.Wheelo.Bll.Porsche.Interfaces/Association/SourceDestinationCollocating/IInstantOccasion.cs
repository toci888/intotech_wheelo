using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating
{
    public interface IInstantOccasion
    {
        List<Trip> FindOccasionalTrips(int accountId, TimeOnly timeFromTo, bool fromTo);

        int AddOccasion(int tripId, int occasionAccountId);
    }
}
