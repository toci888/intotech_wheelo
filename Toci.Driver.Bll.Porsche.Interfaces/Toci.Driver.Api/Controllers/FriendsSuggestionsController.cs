﻿using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsSuggestionsController : ApiSimpleControllerBase<IFriendsSuggestionsService>
    {
        public FriendsSuggestionsController(IFriendsSuggestionsService logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("get-friends-suggestions")]
        public List<Vfriendsuggestion> GetSuggestions(int accountId)
        {
            return Logic.GetSuggestions(accountId);
        }
    }
}