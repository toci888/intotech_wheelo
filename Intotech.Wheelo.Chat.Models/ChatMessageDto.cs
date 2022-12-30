namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        public int ChatParticipantId { get; set; }
        public int ChatMessageAuthorId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RoomName { get; set; }
        public string RoomId { get; set; }
    }
}