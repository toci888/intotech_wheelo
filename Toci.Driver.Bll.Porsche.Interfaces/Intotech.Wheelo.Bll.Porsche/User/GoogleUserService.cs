using Intotech.Wheelo.Bll.Models.Gaf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class GoogleUserService : GafServiceBase<GoogleUserDto>
    {
        public GoogleUserService() : base("https://www.googleapis.com/")
        {
        }

        public override GoogleUserDto GetUserByToken(string token)
        {
            string json = Request(token, "userinfo/v2/me");

            return JsonSerializer.Deserialize<GoogleUserDto>(json);    
        }
    }
}
