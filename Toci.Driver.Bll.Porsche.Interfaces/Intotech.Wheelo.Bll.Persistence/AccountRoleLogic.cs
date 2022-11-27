using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Bll.Models;
using Microsoft.IdentityModel.Tokens;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Common;
using System.Xml.Linq;
using Intotech.Wheelo.Bll.Models.Account;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class AccountRoleLogic : Logic<Accountrole>, IAccountRoleLogic
    {
        private readonly AuthenticationSettings _authenticationSettings;
        protected Logic<Account> accountLogic = new Logic<Account>();

        public AccountRoleLogic(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        //22CE8D06972A4DEF08FD462C470E60ED1849700D18D96FB472778DB639D1830C

        public Accountrole CreateAccount(AccountRegisterDto user)
        {
            if (isLoginAlreadyInDb(user.Email))
            {
                return null;
            }

            int gender = user.FirstName[user.FirstName.Length - 1] == 'a' ? 2 : 1;

            Account acc = new Account() { Email = user.Email, Name = user.FirstName, 
                Password = user.Password, Surname = user.LastName };

            Account newUser = accountLogic.Insert(acc);

            return GenerateJwt(new LoginDto() { Email = newUser.Email, Password = newUser.Password });
        }

        public Accountrole GenerateJwt(LoginDto user)
        {
            Accountrole u = Select(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (u is null)
            {
                //throw new Exception("Invalid username or password");
                //throw new BadRequestException("Invalid username or password");
                return null;
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{u.Name} {u.Surname}"),
                new Claim(ClaimTypes.Role, $"{u.Name}"),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            u.Token = tokenHandler.WriteToken(token);
            return u;
        }

        public int ResetPassword(int userId, string password)
        {
            Account user = accountLogic.Select(m => m.Id == userId).FirstOrDefault();

            user.Password = password;

            return accountLogic.Update(user).Id;
        }

        public IEnumerable<Account> GetAll()
        {
            return accountLogic.Select(m => m.Id > 0);
        }

        protected virtual bool isLoginAlreadyInDb(string email)
        {
            return accountLogic.Select(x => x.Email == email).Any();
        }
    }
}
