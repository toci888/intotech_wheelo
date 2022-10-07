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
        public bool CalculateAssociation(double longitude, double latitude, double candidateLongitude, double candidateLatitude, double acceptableDistance)
        {
          return Math.Sqrt(Math.Pow(Math.Abs(longitude - candidateLongitude), 2) + Math.Pow(Math.Abs(latitude - candidateLatitude), 2))<acceptableDistance;
        }
    }
}
