using System.Reflection.Metadata.Ecma335;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Chat.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    [Authorize(Roles = "User")]
    public class ConversationController : ApiSimpleControllerBase<IConversationService>
    {
        public ConversationController(IConversationService service) : base(service)
        {
        }

        [HttpGet("get-conversation-by-id")]
        public ConversationDto GetConversationById(int roomId)
        {
            return Service.GetConversationById(roomId);
        }

        [HttpGet("get-conversations-by-user-id")]
        public List<ConversationDto> GetConversationsByAccountId(int userId)
        {
            return Service.GetConversationsByAccountId(userId);
        }
    }
}
