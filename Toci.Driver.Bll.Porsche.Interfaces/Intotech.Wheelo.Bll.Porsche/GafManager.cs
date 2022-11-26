﻿using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Wheelo.Bll.Porsche.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche
{
    public class GafManager : IGafManager
    {
        protected IUserExtraDataLogic LUserExtraDataLogic;
        protected IAccountLogic AccLogic;

        public GafManager(IUserExtraDataLogic lUserExtraDataLogic, IAccountLogic accLogic)
        {
            LUserExtraDataLogic = lUserExtraDataLogic;
            AccLogic = accLogic;
        }

        public virtual Accountrole RegisterByMethod(string method, string token)
        {
            Userextradatum userextradatum = new Userextradatum();
            Account account = new Account();

            if (method == "google")
            {
                GoogleUserDto dto = new GoogleUserService().GetUserByToken(token);

                return GoogleAccountExtraData(dto, token);
            }

            if (method == "facebook")
            {
                FacebookUserDto dto = new FacebookUserService().GetUserByToken(token);

                return FacebookAccountExtraData(dto, token);
            }

            return null;
        }

        protected virtual Accountrole GoogleAccountExtraData(GoogleUserDto dto, string token)
        {
            Accountrole accountrole = AccLogic.CreateAccount(new AccountRegisterDto() { Email = dto.email, Name = dto.name, Surname = dto.given_name  });

            LUserExtraDataLogic.Insert(new Userextradatum() { Idaccount = accountrole.Id, Token = token, Tokendatajson = dto.Json });

            return accountrole;
        }

        protected virtual Accountrole FacebookAccountExtraData(FacebookUserDto dto, string token)
        {
            string[] nameSurname = dto.name.Split(" ");
            string name = string.Empty;
            string surname = string.Empty;

            if (nameSurname.Length == 2)
            {
                name = nameSurname[0];
                surname= nameSurname[1];
            }

            Accountrole accountrole = AccLogic.CreateAccount(new AccountRegisterDto() { 
                Email = dto.email, Name = name, Surname = surname, Phone = string.Empty, Password = string.Empty, Method = "facebook" });

            LUserExtraDataLogic.Insert(new Userextradatum() { Idaccount = accountrole.Id, Token = token, Tokendatajson = dto.Json });

            return accountrole;
        }
    }
}
