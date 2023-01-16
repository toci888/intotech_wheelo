using Intotech.Common;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Intotech.Common.ImageManagement;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class FacebookUserService : GafServiceBase<FacebookUserDto>
    {
        protected IAccountLogic AccountLogic;
        protected IUserExtraDataLogic UserExtraDataLogic;
        protected ImageManager ImageManager;

        public FacebookUserService(IAccountLogic accountLogic, IUserExtraDataLogic userExtraDataLogic) : base("https://graph.facebook.com/")
        {
            AccountLogic = accountLogic;
            UserExtraDataLogic = userExtraDataLogic;
            ImageManager = new ImageManager();
        }

        public override FacebookUserDto GetUserByToken(string token)
        {
            string json = Request(token, "me?fields=id,name,email,picture&access_token=" + token);

            FacebookUserDto dto = JsonSerializer.Deserialize<FacebookUserDto>(json);

            if (dto.email == null)
            {
                return null;
            }

            dto.Json = json;

            string[] nameSurname = dto.name.Split(" ");

            string name = string.Empty;
            string surname = string.Empty;

            if (nameSurname.Length == 2)
            {
                name = nameSurname[0];
                surname = nameSurname[1];
            }

            Account acc = AccountLogic.Select(m => m.Email == dto.email).FirstOrDefault();

            if (acc != null)
            {
                Userextradatum userExtra = UserExtraDataLogic.Select(m => m.Idaccount == acc.Id).FirstOrDefault();

                if (string.IsNullOrEmpty(acc.Name) && string.IsNullOrEmpty(acc.Surname))
                {
                    acc.Name = name;
                    acc.Surname = surname;
                }

                acc.Image = ImageManager.GetImageBase64(dto.picture.data.url); //dto.picture.data.url

                AccountLogic.Update(acc);

                if (userExtra == null)
                {
                    UserExtraDataLogic.Insert(new Userextradatum() { Idaccount = acc.Id, Origin = CommonConstants.FacebookOrigin, Token = token, Tokendatajson = json });
                }
            }
            else
            {
                string refreshToken = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);
                DateTime refreshTokenValid = DateTime.Now.AddDays(AccountLogicConstants.RefreshTokenValidDays);

                acc = AccountLogic.Insert(new Account() { Email = dto.email, Emailconfirmed = true, Idrole = CommonConstants.RoleUser, 
                    Image = dto.picture.data.url, Name = name, Surname = surname, Refreshtoken = refreshToken, Refreshtokenvalid = refreshTokenValid });

                UserExtraDataLogic.Insert(new Userextradatum() { Idaccount = acc.Id, Origin = CommonConstants.FacebookOrigin, Token = token, Tokendatajson = json });
            }

            return dto;
        }
    }
}
