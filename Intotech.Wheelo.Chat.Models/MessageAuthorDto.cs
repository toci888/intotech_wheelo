using Org.BouncyCastle.Asn1.Cmp;

namespace Intotech.Wheelo.Chat.Models;

public class MessageAuthorDto
{
    public string SenderEmail { get; set; }
    public string MessageAuthorFirstName { get; set; }
    public string MessageAuthorLastName { get; set; }
    public int AccountId { get; set; }
    public string ImageUrl { get; set; }
}