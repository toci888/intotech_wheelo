using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Driver.Bll.Porsche.Interfaces.Association
{
    public interface IAssociationCalculations
    {
        bool CalculateAssociation(double longitude, double latitude, double candidateLongitude, double candidateLatitude, double acceptableDistance);

        double DistanceInKmBetweenEarthCoordinates(double latitude, double longitude, double candidateLatitude, double candidateLongitude);
    }
}
