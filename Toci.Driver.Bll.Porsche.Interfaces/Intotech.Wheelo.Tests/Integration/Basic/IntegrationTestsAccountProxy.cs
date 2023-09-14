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
    public class IntegrationTestsAccountProxy : IntegrationTestsBaseProxy
    {
        public virtual AccountRoleDto Register()
        {
            AccountRegisterDto accountRegisterDto = new AccountRegisterDto();

            accountRegisterDto.Language = "pl-PL";
            accountRegisterDto.FirstName = "Bartek";
            accountRegisterDto.LastName = "Fartek";
            accountRegisterDto.Email = "warriorr@poczta.fm";
            accountRegisterDto.Password = "password";

            ReturnedResponse<AccountRoleDto> result = ApiPost<ReturnedResponse<AccountRoleDto>, AccountRegisterDto>("api/Account/register", accountRegisterDto, false);

            return result.MethodResult;
        }

        public virtual AccountRoleDto ConfirmEmail(int code)
        {
            EmailConfirmDto emailConfirmDto = new EmailConfirmDto() 
            {
                Language = "pl-PL",
                Email = "warriorr@poczta.fm",
                Code = code
            };

            ReturnedResponse<AccountRoleDto> result = ApiPost<ReturnedResponse<AccountRoleDto>, EmailConfirmDto>("api/Account/confirm-email", emailConfirmDto, false);

            return result.MethodResult;
        }

        public virtual AccountRoleDto Login()
        {
            LoginDto element = new LoginDto();

            element.Language = "pl-PL";
            element.Email = "warriorr@poczta.fm";
            element.Password = "password";
            element.Method = "method";
            element.Token = "doopa123";

            ReturnedResponse<AccountRoleDto> result = ApiPost<ReturnedResponse<AccountRoleDto>, LoginDto>("api/Account/login", element, false);

            return result.MethodResult;
        }


    }
}
