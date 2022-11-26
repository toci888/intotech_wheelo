using Intotech.Wheelo.Bll.Models.Gaf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class FacebookUserService : GafServiceBase<FacebookUserDto>
    {
        public FacebookUserService() : base("https://graph.facebook.com/")
        {
        }

        public override FacebookUserDto GetUserByToken(string token)
        {
            string json = Request(token, "me?fields=id,name,email,picture&access_token=" + token);

            FacebookUserDto dto = JsonSerializer.Deserialize<FacebookUserDto>(json);

            dto.Json = json;

            return dto;
        }
    }
}
