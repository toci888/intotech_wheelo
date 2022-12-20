using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class GoogleUserService : GafServiceBase<GoogleUserDto>
    {
        protected IAccountLogic AccountLogic;
        protected IUserExtraDataLogic UserExtraDataLogic;

        public GoogleUserService(IAccountLogic accountLogic, IUserExtraDataLogic userExtraDataLogic) : base("https://www.googleapis.com/")
        {
            AccountLogic = accountLogic;
            UserExtraDataLogic = userExtraDataLogic;
        }

        public override GoogleUserDto GetUserByToken(string token)
        {
            string json = Request(token, "userinfo/v2/me");

            GoogleUserDto dto = JsonSerializer.Deserialize<GoogleUserDto>(json);    

            dto.Json = json;

            Account acc = AccountLogic.Select(m => m.Email == dto.email).FirstOrDefault();

            if (acc != null)
            {
                Userextradatum userExtra = UserExtraDataLogic.Select(m => m.Idaccount == acc.Id).FirstOrDefault();

                if (string.IsNullOrEmpty(acc.Name) && string.IsNullOrEmpty(acc.Surname))
                {
                    acc.Name = dto.name;
                    acc.Surname = dto.given_name;
                }

                acc.Image = dto.picture;

                AccountLogic.Update(acc);

                if (userExtra == null)
                {
                    UserExtraDataLogic.Insert(new Userextradatum() { Idaccount = acc.Id, Origin = CommonConstants.GoogleOrigin, Token = token, Tokendatajson = json });
                }
            }
            else
            {
                acc = AccountLogic.Insert(new Account()
                {
                    Email = dto.email,
                    Emailconfirmed = dto.verified_email,
                    Idrole = CommonConstants.RoleUser,
                    Image = dto.picture,
                    Name = dto.name,
                    Surname = dto.given_name,
                });

                UserExtraDataLogic.Insert(new Userextradatum() { Idaccount = acc.Id, Origin = CommonConstants.FacebookOrigin, Token = token, Tokendatajson = json });
            }

            return dto;
        }
    }
}
