namespace Intotech.Wheelo.Bll.Models.Account;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Method { get; set; }
    public string Token { get; set; }
}