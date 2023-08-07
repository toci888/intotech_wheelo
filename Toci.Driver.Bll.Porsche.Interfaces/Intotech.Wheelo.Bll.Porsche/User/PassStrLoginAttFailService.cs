using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class PassStrLoginAttFailService : IPassStrLoginAttFailService
    {
        protected IFailedloginattemptLogic FailedloginattemptLogic;
        public PassStrLoginAttFailService(IFailedloginattemptLogic failedloginattemptLogic)
        {
            FailedloginattemptLogic = failedloginattemptLogic;
        }

        public ReturnedResponse<Failedloginattempt> SetFailedLoginAttempt(Failedloginattempt failedloginattempt)
        {
            Failedloginattempt result = FailedloginattemptLogic.Insert(failedloginattempt);

            return new ReturnedResponse<Failedloginattempt>(result, I18nTranslationDep.Translation(I18nTags.Success),
                true, ErrorCodes.Success);
        }
    }
}
