using Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace Intotech.Wheelo.Proxies
{
    public abstract class HttpClientProxyBase
    {
        protected HttpClient HttpProxy;

        protected HttpClientProxyBase(string serverUrl)
        {
            HttpProxy = new HttpClient();
            HttpProxy.BaseAddress = new Uri(serverUrl);
        }

        public virtual TResponse ApiPost<TRequest, TResponse>(TRequest requestDto, string apiResource)
        {
            HttpContent content = JsonContent.Create(requestDto);

            HttpResponseMessage response = HttpProxy.PostAsync(apiResource, content).Result;

            return JObject.Parse(response.Content.ReadAsStringAsync().Result).ToObject<TResponse>();
        }
    }
}