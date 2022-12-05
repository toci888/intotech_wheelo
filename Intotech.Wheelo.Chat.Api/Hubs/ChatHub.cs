using Intotech.Wheelo.Chat.Api.Logic;
using Intotech.Wheelo.Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Intotech.Wheelo.Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private const string ClientReceiveMessageCallback = "ReceiveMessage";

        protected ChatLogic ChatLogic;

        public ChatHub(ChatLogic chatLogic)
        {
            ChatLogic = chatLogic;
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            await Clients.Group(chatMessage.RoomId).SendAsync(ClientReceiveMessageCallback, chatMessage);

            ChatLogic.SendMessage(chatMessage);
        }

        public async Task JoinWheeloRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
