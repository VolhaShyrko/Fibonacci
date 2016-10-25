using System;
using StackExchange.Redis;

namespace FibonacciNumber
{
    public class RedisCacheHelper
    {
        static RedisCacheHelper()
        {
            RedisCacheHelper.cache = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost"));
        }

        private static Lazy<ConnectionMultiplexer> cache;

        public static IDatabase Cache
        {
            get
            {
                return cache.Value.GetDatabase();
            }
        }
    }
}