using Intotech.Wheelo.Common.ImageService;

namespace Intotech.Wheelo.Chat.Models;

public class ConversationDto 
{
    public int IdRoom { get; set; }
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public int IdAccount { get; set; }
    public string OwnerEmail { get; set; }
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ChatMessageDto> Messages { get; set; }
    public List<MessageAuthorDto> RoomParticipants { get; set; }
    
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