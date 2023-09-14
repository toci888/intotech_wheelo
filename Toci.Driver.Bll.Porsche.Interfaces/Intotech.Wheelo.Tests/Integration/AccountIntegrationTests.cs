using Intotech.Wheelo.Bll.Models.OldModels;
using Intotech.Wheelo.Tests.Integration.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Integration
{
    public class AccountIntegrationTests
    {
        protected IntegrationTestsAccountProxy AccountProxy = new IntegrationTestsAccountProxy();
        public AccountRoleDto Register()
        {
            AccountRoleDto registerResult = AccountProxy.Register();

            return registerResult;
        }
    }
}
