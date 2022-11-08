using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;

namespace Toci.Driver.Bll.Porsche.Association
{
    public class AssociationCalculations : IAssociationCalculations
    {
        public bool CalculateAssociation(double latitude, double longitude, double candidateLatitude, double candidateLongitude, double acceptableDistance)
        {
            double dist = Math.Sqrt(Math.Pow(Math.Abs(candidateLongitude - longitude), 2) + Math.Pow(Math.Abs(candidateLatitude - latitude), 2));

            return dist < acceptableDistance;
        }

        protected virtual double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public virtual double DistanceInKmBetweenEarthCoordinates(double latitude, double longitude, double candidateLatitude, double candidateLongitude)
        {
            double earthRadiusKm = 6371;

            double dLat = DegreesToRadians(latitude - candidateLatitude);
            double dLon = DegreesToRadians(longitude - candidateLongitude);

            latitude = DegreesToRadians(latitude);
            candidateLatitude = DegreesToRadians(candidateLatitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) 
                * Math.Cos(latitude) * Math.Cos(candidateLatitude);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadiusKm * c;
        }
    }
}
