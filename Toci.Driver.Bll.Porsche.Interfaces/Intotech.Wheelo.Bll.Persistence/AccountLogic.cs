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

namespace Intotech.Wheelo.Bll.Persistence
{
    public class AccountLogic : Logic<Accountrole>, IAccountLogic
    {
        private readonly AuthenticationSettings _authenticationSettings;
        protected Logic<Account> accountLogic = new Logic<Account>();

        public int CreateAccount(Account user)
        {
            if (isLoginAlreadyInDb(user.Email))
            {
                return 0;
            }

            user.Password = HashPassword(user.Password);

            Account newUser = accountLogic.Insert(user);

            return newUser.Id;
        }

        public Accountrole GenerateJwt(LoginDto user)
        {
            string hash = HashPassword(user.Password);
            Accountrole u = Select(x => x.Email == user.Email && x.Password == hash).FirstOrDefault();

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

        private string HashPassword(string password)
        {
            if (password == null)
            {
                return null;
            }

            SHA256 algorithm = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (Byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
