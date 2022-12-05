using Microsoft.AspNetCore.SignalR;

namespace Intotech.Wheelo.Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        private const string ClientReceiveMessageCallback = "ReceiveMessage";

        public async Task SendMessage(string message, string user, string room)
        {
            await Clients.Group(room).SendAsync(ClientReceiveMessageCallback, user, message);
        }

        public async Task JoinRoomFuck(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }
    }
}
