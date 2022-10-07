using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Association
{
    public class AssociationEntity : IAssociationEntity
    {
        public WorkTrip Current { get; set; }
        public List<WorkTrip> Associatated { get ; set ; }

    }
}
