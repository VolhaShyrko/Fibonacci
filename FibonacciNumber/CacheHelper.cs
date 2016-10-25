using System.Runtime.Caching;

namespace FibonacciNumber
{
    public class CacheHelper
    {
        static CacheHelper()
        {
            CacheHelper.cache = MemoryCache.Default;
        }

        private static ObjectCache cache;

        public static ObjectCache Cache
        {
            get
            {
                return cache;
            }
        }
    }
}