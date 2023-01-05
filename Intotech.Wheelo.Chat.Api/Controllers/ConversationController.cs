using Intotech.Common.Microservices;
using Intotech.Wheelo.Chat.Jaguar.Interfaces;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Wheelo.Chat.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class ConversationController : ApiSimpleControllerBase<IConversationService>
    {
        public ConversationController(IConversationService service) : base(service)
        {
        }

        [HttpGet("get-conversation-by-id")]
        public List<ConversationDto> GetConversationById(string roomId)
        {
            return Service.GetConversationById(roomId);
        }
    }
}
