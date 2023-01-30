namespace Intotech.Wheelo.Common.Interfaces.CachingService;

public interface ICachingService
{
    bool Set<TCacheEntity>(string key, TCacheEntity cacheEntity);
    TCacheEntity Get<TCacheEntity>(string key);
    bool Update<TCacheEntity>(string key, TCacheEntity cacheEntity);
    bool Delete(string key);
}