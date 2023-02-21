using Org.BouncyCastle.Asn1.Cmp;

namespace Intotech.Wheelo.Chat.Models;

public class MessageAuthorDto
{
    public string SenderEmail { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastSeen { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Role { get; set; }
    public int IdRoom { get; set; }
    public string RoomId { get; set; }

}
