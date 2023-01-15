using Intotech.Wheelo.Proxies.IntotechWheeloApi.Models;

namespace Intotech.Wheelo.Proxies.IntotechWheeloApi.Interfaces;

public interface IAccountProxy
{
    AccountRegisterResponseDto Register(AccountRegisterDto registerDto);
}