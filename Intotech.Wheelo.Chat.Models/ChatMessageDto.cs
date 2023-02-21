using Intotech.Wheelo.Common.ImageService;

namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        public int Id { get; set; }   
        public string Text { get; set; }
        public string SenderEmail { get; set; }
   
        public string RoomId { get; set; }

        public int IdAccount { get; set; }
        public DateTime CreatedAt { get; set; }

        

    }
    
}