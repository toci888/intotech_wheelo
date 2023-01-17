using Intotech.Wheelo.Common.ImageService;

namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        public string SenderEmail { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ID { get; set; }
        public int IdAccount { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string ImageUrl { get; set; }
        public int RoomID { get; set; }
    }
    
}