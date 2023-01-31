namespace Intotech.Wheelo.Chat.Models;

public class RoomMembersDto
{
    public int IdAccount { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string[] PushTokens { get; set; }
}