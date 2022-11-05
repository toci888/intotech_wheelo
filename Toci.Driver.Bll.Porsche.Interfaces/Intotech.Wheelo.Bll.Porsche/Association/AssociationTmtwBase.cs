using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Bll.Porsche.Association
{
    public abstract class AssociationTmtwBase : IAssociationTmtw
    {
        protected IAssociationCalculations AssociationCalculations;

        protected AssociationTmtwBase(IAssociationCalculations associationCalculations)
        {
            AssociationCalculations = associationCalculations;
        }

        public abstract Worktrip GetAssociations(Worktrip subject, Worktrip candidateSubject);

        public List<IAssociationEntity> GetAssociationsFromCollection(Worktrip requested, List<Worktrip> subjects)
        {
            List <IAssociationEntity> result = new List<IAssociationEntity>();

            foreach (Worktrip item in subjects)
            {
                IAssociationEntity entity = new AssociationEntity();
                entity.Current = requested;
                
                Worktrip associated = GetAssociations(requested, item);
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
