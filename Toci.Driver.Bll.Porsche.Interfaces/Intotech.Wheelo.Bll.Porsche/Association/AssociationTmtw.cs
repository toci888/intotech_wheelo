using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Bll.Porsche.Association
{
    public class AssociationTmtw : AssociationTmtwBase
    {
        public AssociationTmtw(IAssociationCalculations associationCalculations) : base(associationCalculations)
        {
        }
        
        public override Worktrip GetAssociations(Worktrip subject, Worktrip candidateSubject)
        {
            bool hoursMatch = subject.Fromhour == candidateSubject.Fromhour &&
                              subject.Tohour == candidateSubject.Tohour;

            if (hoursMatch)
            {


                bool isInRange = AssociationCalculations.CalculateAssociation((double)subject.Fromlongitude.Value,
                    (double)subject.Fromlatitude.Value, (double)candidateSubject.Fromlongitude.Value,
                    (double)candidateSubject.Fromlatitude.Value,
                    (double)subject.Acceptabledistance.Value);

                if (isInRange)
                {
                    bool isInRangeTo = AssociationCalculations.CalculateAssociation((double)subject.Tolongitude.Value,
                        (double)subject.Tolatitude.Value, (double)candidateSubject.Tolongitude.Value,
                        (double)candidateSubject.Tolatitude.Value,
                        (double)subject.Acceptabledistance.Value);

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
