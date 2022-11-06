using Intotech.Common.Bll;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.PersistenceAggregation
{
    public class AccountCollocationMatch : TwoAggrLogicBase<IUsersLocationLogic, IUsersCollocationLogic>, IAccountCollocationMatch<IUsersLocationLogic, IUsersCollocationLogic>
    {
        protected IAssociationCalculations AssociationCalculations;

        public AccountCollocationMatch(IUsersLocationLogic firstLogic, IUsersCollocationLogic secondLogic, IAssociationCalculations associationCalculation) : base(firstLogic, secondLogic)
        {
            AssociationCalculations = associationCalculation;
        }

        public bool TryCollocate(int idUserFirst, int idUserSecod)
        {
            Accountslocation firstUserLocation = FirstLogic.Select(m => m.Id == idUserFirst).First();
            Accountslocation secondUserLocation = FirstLogic.Select(m => m.Id == idUserFirst).First();

            // firstUserLocation.Coordinatesfrom ??

           // AssociationCalculations.CalculateAssociation();

            return true;
        }
    }
}
