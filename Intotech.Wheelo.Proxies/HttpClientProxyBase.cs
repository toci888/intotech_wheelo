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
    }
}