using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace SFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager:ICacheManager
    {

        protected ObjectCache Cache => MemoryCache.Default;

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Add(string key, object data, int cacheTimeInMinutes = 10)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTimeInMinutes) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsAdded(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            keysToRemove.ForEach(Remove);
        }

        public void Clear()
        {
            foreach (var item in Cache) Remove(item.Key);
        }
    }
}
