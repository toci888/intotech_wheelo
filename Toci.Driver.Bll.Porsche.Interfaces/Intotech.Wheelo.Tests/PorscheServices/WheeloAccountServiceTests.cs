using Intotech.Common;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Bll.Porsche.User;
using Intotech.Common.Bll.ComplexResponses;

namespace Intotech.Wheelo.Tests.PorscheServices
{
    [TestClass]
    public class WheeloAccountServiceTests
    {
        IWheeloAccountService AccountService;   

        public WheeloAccountServiceTests() 
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<AuthenticationSettings, AuthenticationSettings>();
            services.AddScoped<IAccountLogic, AccountLogic>();
            services.AddScoped<IAccountRoleLogic, AccountRoleLogic>();
            services.AddScoped<IFailedloginattemptLogic, FailedloginattemptLogic>();
            services.AddScoped<IResetpasswordLogic, ResetpasswordLogic>();
            services.AddScoped<IWheeloAccountService, WheeloAccountService>();
            services.AddScoped<IAccountmodeLogic, AccountmodeLogic>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            AccountService = serviceProvider.GetService<IWheeloAccountService>();
        }

        [TestMethod]
        public void RegisterTest()
        {
            AccountRegisterDto testData = GetRegisterData();

            ReturnedResponse<AccountRegisterDto> result = AccountService.Register(testData);

            ReturnedResponse<AccountRegisterDto> secResult = AccountService.Register(testData);

           // result.ErrorCode ?
           // secResult.ErrorCode ? 
        }

        protected virtual AccountRegisterDto GetRegisterData()
        {
            return new AccountRegisterDto()
            {
                Email = Guid.NewGuid().ToString(),
                FirstName = StringUtils.GetRandomText(20),
                LastName = StringUtils.GetRandomText(20),
                Password = StringUtils.GetRandomText(20)
            };
        }
    }
}
