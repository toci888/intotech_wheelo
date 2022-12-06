namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        public ChatUserDto User { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RoomName { get; set; }
        public int RoomId { get; set; }
    }
}