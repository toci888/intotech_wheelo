using Intotech.Wheelo.Common.ImageService;

namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        
        public string Text { get; set; }
   
        public int ID { get; set; }

        public AuthorDto Author { get; set; }

    }
    
}