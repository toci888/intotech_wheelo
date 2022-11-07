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


                bool isInRange = AssociationCalculations.CalculateAssociation((double)subject.Longitudefrom.Value,
                    (double)subject.Latitudefrom.Value, (double)candidateSubject.Longitudefrom.Value,
                    (double)candidateSubject.Latitudefrom.Value,
                    (double)subject.Acceptabledistance.Value);

                if (isInRange)
                {
                    bool isInRangeTo = AssociationCalculations.CalculateAssociation((double)subject.Longitudeto.Value,
                        (double)subject.Latitudeto.Value, (double)candidateSubject.Longitudeto.Value,
                        (double)candidateSubject.Latitudeto.Value,
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
