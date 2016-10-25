using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace FibonacciNumber
{
    public class CacheManager : ICacheManager
    {
        public List<int> Get(string key)
        {
            object value = CacheHelper.Cache.Get(key);
            return value as List<int>;
        }

        public void Set(string key, List<int> value)
        {
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };
            CacheHelper.Cache.Set(key, value, policy);
        }
    }
}