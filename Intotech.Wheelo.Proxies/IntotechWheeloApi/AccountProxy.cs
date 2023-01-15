using System.Net.Http.Json;
using System.Text.Json;
using Intotech.Wheelo.Proxies.IntotechWheeloApi.Interfaces;
using Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;
using Newtonsoft.Json.Linq;

namespace Intotech.Wheelo.Proxies.IntotechWheeloApi;

public class AccountProxy : HttpClientProxyBase, IAccountProxy
{
    protected string apiAccountRegisterResource = "api/Account/register";

    public AccountProxy() : base(ServersUrls.IntotechWheeloApiUrl)
    {
    }

    public virtual AccountRegisterResponseDto Register(AccountRegisterDto registerDto)
    {
        HttpContent content = JsonContent.Create(registerDto);

        HttpResponseMessage response = HttpProxy.PostAsync(apiAccountRegisterResource, content).Result;

        return JObject.Parse(response.Content.ReadAsStringAsync().Result).ToObject<AccountRegisterResponseDto>();
    }
}