using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public abstract class GafServiceBase<TTokenContent> : IGafService<TTokenContent> where TTokenContent : class
    {
        protected HttpClient HttpClient;

        protected string ApiUrl;

        protected GafServiceBase(string apiUrl)
        {
            HttpClient = new HttpClient();
            ApiUrl = apiUrl;
        }

        protected virtual string Request(string token, string uri)
        {
            HttpClient.BaseAddress = new Uri(ApiUrl);
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" + token);

            return HttpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            //ya29.a0AeTM1ifhnlv61CrcLF13LfTZ32IuaoUnSvMvCqriiwLgX8sIGJmsyLFI9DRUxyyZc4OidrA83Dqs0MfF-BShtIsjxIFom6grHJpJs_msP5XZa_Y5mN_j2gHKlSLCKFleODI235_Qv-gT8Z6NbZGaF4VBxY32aCgYKAYMSARMSFQHWtWOm1x2JEJ44V7OR78PwhocQ4Q0163
        }

        public abstract TTokenContent GetUserByToken(string token);
    }
}
