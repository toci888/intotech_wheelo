using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Dodge.Interfaces;
using Intotech.Wheelo.Chat.Models.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Dodge
{
    public class AccountService : IAccountService
    {
        protected IAccountLogic AccountLogic;
        protected IPushtokenLogic PushtokenLogic;

        public AccountService(IAccountLogic accountLogic, IPushtokenLogic pushtokenLogic)
        {
            AccountLogic = accountLogic;
            PushtokenLogic = pushtokenLogic;
        }

        public virtual UserCacheDto GetAccount(string email)
        {
            Account account = AccountLogic.Select(m => m.Email == email).FirstOrDefault();

            if (account == null)
            {
                return null;
            }

            return GetAccount(account);
        }

        public virtual UserCacheDto GetAccount(int idAccount)
        {
            Account account = AccountLogic.Select(m => m.Id == idAccount).FirstOrDefault();

            if (account == null)
            {
                return null;
            }

            return GetAccount(account);
        }

        protected virtual UserCacheDto GetAccount(Account account)
        {
            UserCacheDto ucDto = new UserCacheDto();

            ucDto.UserSurname = account.Surname;
            ucDto.IdAccount = account.Id;
            //ucDto.ImageUrl = account.Image;
            ucDto.SessionId = ucDto.SenderEmail = account.Email;
            ucDto.UserName = account.Name;
            ucDto.AccountCreatedAt = account.Createdat.Value;

            ucDto.PushTokens = PushtokenLogic.Select(m => m.Idaccount == account.Id).Select(m => m.Token).ToArray();

            return ucDto;
        }
    }
}
