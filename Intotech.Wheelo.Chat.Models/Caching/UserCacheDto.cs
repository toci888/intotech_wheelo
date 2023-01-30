namespace Intotech.Wheelo.Chat.Models.Caching;

[Serializable]
public class UserCacheDto
{
    public string SenderEmail { get; set; }
    public int IdAccount { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string SessionId { get; set; }
    public string ImageUrl { get; set; }
}