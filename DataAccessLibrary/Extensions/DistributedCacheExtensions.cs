using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLibrary.Extensions
{
    public static class DistributedCacheExtensions
    {
        // Extension Method for Redis Set
        public static async Task SetEntryAsync<T>(this IDistributedCache cache,
            string key,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? idleExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = idleExpireTime;

            var jsonData = JsonSerializer.Serialize(data);

            await cache.SetStringAsync(key, jsonData, options);
        }


        // Extension Method for Redis Get
        public static async Task<T> GetEntryAsync<T>(this IDistributedCache cache, string key)
        {
            var jsonData = await cache.GetStringAsync(key);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }

}
