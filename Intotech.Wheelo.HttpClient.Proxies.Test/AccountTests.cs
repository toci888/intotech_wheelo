using Intotech.Wheelo.Proxies.IntotechWheeloApi;
using Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;

namespace Intotech.Wheelo.HttpClient.Proxies.Test
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void TestRegisterAccount()
        {
            AccountProxy proxy = new AccountProxy();

            AccountRegisterResponseDto registerResult = proxy.Register(new AccountRegisterDto() { email = "glockajulia@gmail.com", firstName = "Julia", lastName = "G³ocka", password = "fbd623cdcf27c1cf99595b52154e699d1ae95e7c48bd7c34ba73d0091a5b2af2" });
        }
    }
}