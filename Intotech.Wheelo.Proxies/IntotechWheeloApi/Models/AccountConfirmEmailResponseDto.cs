namespace Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;

public class AccountConfirmEmailResponseDto
{
    public AccountConfirmEmailResponseResult methodResult { get; set; }
    public string errorMessage { get; set; }
    public bool isSuccess { get; set; }
    public int errorCode { get; set; }
}

public class AccountConfirmEmailResponseResult
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string accessToken { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public bool emailconfirmed { get; set; }
    public string refreshtoken { get; set; }
    public string rolename { get; set; }
    public DateTime refreshtokenvalid { get; set; }
    public bool allowsnotifications { get; set; }
}