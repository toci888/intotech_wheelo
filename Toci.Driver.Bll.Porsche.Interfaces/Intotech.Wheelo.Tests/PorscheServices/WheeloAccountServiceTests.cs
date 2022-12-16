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
using Intotech.Wheelo.Common.Interfaces;

namespace Intotech.Wheelo.Tests.PorscheServices
{
    [TestClass]
    public class WheeloAccountServiceTests
    {
        IWheeloAccountService AccountService;
        IWheeloAccountService SecAccountService;

        public WheeloAccountServiceTests() 
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<AuthenticationSettings, AuthenticationSettings>();
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<IAccountRoleLogic, AccountRoleLogic>();
            services.AddTransient<IFailedloginattemptLogic, FailedloginattemptLogic>();
            services.AddTransient<IResetpasswordLogic, ResetpasswordLogic>();
            services.AddTransient<IPushtokenLogic, PushtokenLogic>();
            services.AddTransient<IWheeloAccountService, WheeloAccountService>();
            services.AddTransient<IAccountmodeLogic, AccountmodeLogic>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            AccountService = serviceProvider.GetService<IWheeloAccountService>();
            SecAccountService = serviceProvider.GetService<IWheeloAccountService>();
        }

        [TestMethod]
        public void RegisterTest()
        {
            AccountRegisterDto testData = GetRegisterData();

            ReturnedResponse<AccountRoleDto> result = AccountService.Register(testData);

            Assert.AreEqual(result.ErrorCode, ErrorCodes.DataIntegrityViolated);

            testData.Email = "warriorr@poczta.fm";

            ReturnedResponse<AccountRoleDto> secResult = SecAccountService.Register(testData);

            Assert.AreEqual(secResult.ErrorCode, ErrorCodes.Success);

            secResult = SecAccountService.Register(testData);

            Assert.AreEqual(secResult.ErrorCode, ErrorCodes.PleaseConfirmEmail);

            testData.Password = StringUtils.GetRandomText(20);

            secResult = SecAccountService.Register(testData);

            Assert.AreEqual(secResult.ErrorCode, ErrorCodes.PleaseConfirmEmail);

            for (int i = 0; i < 6; i++)
            {
                secResult = SecAccountService.Register(testData);
            }

            Assert.AreEqual(secResult.ErrorCode, ErrorCodes.UnderAttack);

           
            CleanUp();
        }

        protected virtual void CleanUp()
        {

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
