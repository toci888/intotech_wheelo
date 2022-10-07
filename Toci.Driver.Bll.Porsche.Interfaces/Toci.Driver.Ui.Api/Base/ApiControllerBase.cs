using System.Web.Http;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Ui.Api.Base
{
    public class ApiControllerBase<TModel> : ApiController
    {
        private readonly IDal<TModel> _driverEntities;

        public ApiControllerBase(IDal<TModel> driverEntities)
        {
            _driverEntities = driverEntities;
        }
    }
}