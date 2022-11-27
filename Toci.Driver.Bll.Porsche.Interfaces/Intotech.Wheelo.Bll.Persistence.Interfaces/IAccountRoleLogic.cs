﻿using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.Interfaces;

public interface IAccountRoleLogic : ILogicBase<Accountrole>
{
    public Accountrole CreateAccount(AccountRegisterDto user);
    public Accountrole GenerateJwt(LoginDto user);
    public IEnumerable<Account> GetAll();
    public int ResetPassword(int userId, string password);
}
