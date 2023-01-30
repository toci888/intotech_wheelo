using Enyim.Caching.Memcached;
using MemcachedClient = Enyim.Caching.MemcachedClient;

namespace Intotech.Wheelo.Chat.Tests;

[TestClass]
public class CachingPoc
{
    [Serializable]
    public class doopa
    {
        public int id;
    }

    [TestMethod]
    public void TestMemcached()
    {
        MemcachedCluster memCluster = new MemcachedCluster("localhost:11211");

        memCluster.Start();

        IMemcachedClient client = memCluster.GetClient();

        bool res = client.SetAsync("Ghostrider", new doopa() { id = 8 }, Expiration.Never).Result;

        var result = client.GetAsync("Ghostrider").Result;
    }

    [TestMethod]
    public void GetFromMemcached()
    {
        MemcachedCluster memCluster = new MemcachedCluster("localhost:11212");

        memCluster.Start();

        IMemcachedClient client = memCluster.GetClient();

        var result = client.GetAsync("Ghostrider").Result;
    }
}