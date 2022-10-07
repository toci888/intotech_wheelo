using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Interfaces.Association
{
   public interface IAssociationEntity
    {
        WorkTrip Current { get; set; }
        List<WorkTrip> Associatated { get; set; }

    }
}
