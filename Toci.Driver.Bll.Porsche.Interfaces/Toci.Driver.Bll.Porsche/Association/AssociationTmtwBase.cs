using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Association
{
    public abstract class AssociationTmtwBase : IAssociationTmtw
    {
        protected IAssociationCalculations AssociationCalculations;

        protected AssociationTmtwBase(IAssociationCalculations associationCalculations)
        {
            AssociationCalculations = associationCalculations;
        }

        public abstract WorkTrip GetAssociations(WorkTrip subject, WorkTrip candidateSubject);

        public List<IAssociationEntity> GetAssociationsFromCollection(WorkTrip requested, List<WorkTrip> subjects)
        {
            List <IAssociationEntity> result = new List<IAssociationEntity>();

            foreach (WorkTrip item in subjects)
            {
                IAssociationEntity entity = new AssociationEntity();
                entity.Current = requested;
                
                WorkTrip associated = GetAssociations(requested, item);
                if (associated != null)
                {
                    entity.Associatated.Add(associated); //entity associated
                }

                result.Add(entity);
            }
            return result;
        }

    }
}
