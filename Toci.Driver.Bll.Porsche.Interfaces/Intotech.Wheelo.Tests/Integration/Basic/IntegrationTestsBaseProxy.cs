using Intotech.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Tests.Integration.Basic
{
    public abstract class IntegrationTestsBaseProxy : HttpClientProxy
    {
        protected IntegrationTestsBaseProxy()
        {
            BaseUrl = "http://89.40.12.1:5015/";
        }
    }
}
