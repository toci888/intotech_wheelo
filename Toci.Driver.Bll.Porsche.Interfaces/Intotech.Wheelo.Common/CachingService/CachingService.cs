using Enyim.Caching.Memcached;
using Intotech.Wheelo.Common.Interfaces.CachingService;

namespace Intotech.Wheelo.Common.CachingService;

public class CachingService : ICachingService
{
    public virtual bool Set<TCacheEntity>(string key, TCacheEntity cacheEntity)
    {
        return MemcachedClient.GetClient().SetAsync(key, cacheEntity).Result;
    }

    public virtual TCacheEntity Get<TCacheEntity>(string key)
    {
        return MemcachedClient.GetClient().GetAsync<TCacheEntity>(key).Result;
    }

    public virtual bool Update<TCacheEntity>(string key, TCacheEntity cacheEntity)
    {
        return MemcachedClient.GetClient().ReplaceAsync(key, cacheEntity).Result;
    }

    public virtual bool Delete(string key)
    {
        return MemcachedClient.GetClient().DeleteAsync(key).Result;
    }
}