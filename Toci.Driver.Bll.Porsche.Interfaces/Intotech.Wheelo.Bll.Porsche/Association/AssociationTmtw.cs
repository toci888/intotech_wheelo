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
           

            return null;
        }


    }
}
