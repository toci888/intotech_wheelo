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
    //[Authorize(Roles = "User")]
    public class ConversationController : ApiSimpleControllerBase<IConversationService>
    {
        public class EmailDto
        {
            public string Email { get; set; }
        }
        public ConversationController(IConversationService service) : base(service)
        {
        }

        [HttpGet("get-conversation-by-id-room")]
        public ConversationDto GetConversationById(int roomId)
        {
            return Service.GetConversationById(roomId);
        }

        [HttpGet("get-conversation-by-id")]
        public ConversationDto GetConversationById(string roomId)
        {
            return Service.GetConversationById(roomId);
        }

        [HttpPost("get-conversations-by-user-email")]
        public FullConversationsDto GetConversationsByAccountId(EmailDto email)
        {
            return Service.GetConversationsByEmail(email.Email);
        }

        [HttpPost("get-room-by-id")]
        public ConversationDto GetPersonalConversation(int IdAccount, int idFriendAccount)
        {
            return Service.GetPersonalConversation(IdAccount, idFriendAccount);
        }
    }
}
