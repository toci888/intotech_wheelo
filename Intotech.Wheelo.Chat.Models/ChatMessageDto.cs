namespace Intotech.Wheelo.Chat.Models
{
    public class ChatMessageDto
    {
        public string SenderID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int RoomID { get; set; }
    }
    /*
         ID: 999, --
    CreatedAt: '02/01/2022', -- 
    ownerID: 3, --
    ownerFirstName: 'ownerfirstname2', --
    ownerLastName: 'ownerlast', --
    ownerEmail: 'ownerEMail', --
    messages: [{
      ID: 1,
      CreatedAt: '01/01/2022',
      senderID: 2,
      text: 'textasd2xx'
    },
     */
}