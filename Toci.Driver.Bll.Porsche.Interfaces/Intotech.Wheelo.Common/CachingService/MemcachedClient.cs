using Enyim.Caching.Memcached;

namespace Intotech.Wheelo.Common.CachingService;

public static class MemcachedClient
{
    private const string MemcachedAddress = "localhost:11211";

    private static MemcachedCluster memCluster; // = new MemcachedCluster("localhost:11211");
    private static IMemcachedClient client;

    public static IMemcachedClient GetClient()
    {
        if (memCluster == null)
        {
            memCluster = new MemcachedCluster(MemcachedAddress);
            memCluster.Start();

            client = memCluster.GetClient();
        }

        return client;
    }
}