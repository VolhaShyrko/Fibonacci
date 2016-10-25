using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace FibonacciNumber
{
    public class RedisCacheManager : ICacheManager
    {
        readonly DataContractSerializer serializer = new DataContractSerializer(typeof(List<int>));

        public List<int> Get(string key)
        {
            byte[] value = RedisCacheHelper.Cache.StringGet(key);
            if (value == null)
            {
                return null;
            }

            return (List<int>)this.serializer.ReadObject(new MemoryStream(value));
        }

        public void Set(string key, List<int> value)
        {
            MemoryStream stream = new MemoryStream();
            this.serializer.WriteObject(stream, value);
            RedisCacheHelper.Cache.StringSet(key, stream.ToArray(), TimeSpan.FromMinutes(5));
        }
    }
}