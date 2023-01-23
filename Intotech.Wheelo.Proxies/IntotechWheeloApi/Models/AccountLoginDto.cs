namespace Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;

public class AccountLoginDto
{
    public string email { get; set; }
    public string password { get; set; }
    public string method { get; set; }
    public string token { get; set; }
}