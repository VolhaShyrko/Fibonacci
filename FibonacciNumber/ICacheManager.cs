using System.Collections.Generic;

namespace FibonacciNumber
{
    public interface ICacheManager
    {
        List<int> Get(string key);
        void Set(string key, List<int> value);
    }
}