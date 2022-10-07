using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Association
{
    public class AssociationTmtw : AssociationTmtwBase
    {
        public AssociationTmtw(IAssociationCalculations associationCalculations) : base(associationCalculations)
        {
        }
        
        public override WorkTrip GetAssociations(WorkTrip subject, WorkTrip candidateSubject)
        {
            bool hoursMatch = subject.FromHour == candidateSubject.FromHour &&
                              subject.ToHour == candidateSubject.ToHour;

            if (hoursMatch)
            {


                bool isInRange = AssociationCalculations.CalculateAssociation((double)subject.FromLongitude.Value,
                    (double)subject.FromLatitude.Value, (double)candidateSubject.FromLongitude.Value,
                    (double)candidateSubject.FromLatitude.Value,
                    (double)subject.AcceptableDistance.Value);

                if (isInRange)
                {
                    bool isInRangeTo = AssociationCalculations.CalculateAssociation((double)subject.ToLongitude.Value,
                        (double)subject.ToLatitude.Value, (double)candidateSubject.ToLongitude.Value,
                        (double)candidateSubject.ToLatitude.Value,
                        (double)subject.AcceptableDistance.Value);

                    if (isInRangeTo)
                    {
                        return candidateSubject;
                    }
                }
            }

            return null;
        }


    }
}
