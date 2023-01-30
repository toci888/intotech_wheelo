using Enyim.Caching.Memcached;

namespace Intotech.Wheelo.Chat.Tests;

public class MemcacheSgl
{
    private static MemcachedCluster memCluster; // = new MemcachedCluster("localhost:11211");
    private static IMemcachedClient client;
   //memCluster.Start();

    //IMemcachedClient client = memCluster.GetClient();
    public static IMemcachedClient GetMemcachedClient()
    {
        //client.ReplaceAsync()
        return client;
    }
}