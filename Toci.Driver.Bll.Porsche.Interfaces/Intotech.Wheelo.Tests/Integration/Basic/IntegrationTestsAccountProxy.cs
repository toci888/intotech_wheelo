using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Http;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Models.OldModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Integration.Basic
{
    public class IntegrationTestsAccountProxy : HttpClientProxy
    {
        public IntegrationTestsAccountProxy()
        {
            BaseUrl = "http://89.40.12.1:5105/";
        }

        public virtual AccountRoleDto Register()
        {
            AccountRegisterDto accountRegisterDto = new AccountRegisterDto();

            accountRegisterDto.Language = "pl-PL";
            accountRegisterDto.FirstName = "Kamila";
            accountRegisterDto.LastName = Guid.NewGuid().ToString();
            accountRegisterDto.Email = "kamila.kwartnik@gmail.com";
            accountRegisterDto.Password = "password";

            ReturnedResponse<AccountRoleDto> result = ApiPost<ReturnedResponse<AccountRoleDto>, AccountRegisterDto>("api/Account/register", accountRegisterDto, false);

            return result.MethodResult;
        }

        public virtual AccountRoleDto Login()
        {
            LoginDto element = new LoginDto();

            element.Language = "pl-PL";
            element.Email = "kamila.kwartnik@gmail.com";
            element.Password = "password";

            ReturnedResponse<AccountRoleDto> result = ApiPost<ReturnedResponse<AccountRoleDto>, LoginDto>("api/Account/login", element, false);

            return result.MethodResult;
        }
    }
}
