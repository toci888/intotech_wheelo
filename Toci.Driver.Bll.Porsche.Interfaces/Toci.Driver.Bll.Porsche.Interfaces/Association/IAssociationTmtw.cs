using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Interfaces.Association
{
    public interface IAssociationTmtw

    {
        WorkTrip GetAssociations(WorkTrip subject, WorkTrip candidateSubject);

       List<IAssociationEntity> GetAssociationsFromCollection(WorkTrip requested, List<WorkTrip> subjects);
    }
}
