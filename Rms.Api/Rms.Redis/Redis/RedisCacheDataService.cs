using StackExchange.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Redis
{
    public class RedisCacheDataService : IRedisCacheDataService, IDisposable
    {
        #region Declarations
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        #endregion
        public RedisCacheDataService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public async Task<List<T>> GetList<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var data = await db.StringGetAsync(key);

            if (data.IsNull)
                return null;

            var decodedObject = JsonConvert.DeserializeObject<T>(data);
            return decodedObject as List<T>;
        }
        public async Task<T> GetCacheValueAsync<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var data = await db.StringGetAsync(key);

            if (data.IsNull)
                return default;

            var decodedObject = JsonConvert.DeserializeObject<T>(data);
            return decodedObject;
        }
        public async Task SetCacheValueAsyn<T>(string key, T record,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var db = _connectionMultiplexer.GetDatabase();

            if (record is null)
                throw new("Null can  not be deserialize");

            var serializedObject = JsonConvert.SerializeObject(record);
            await db.StringSetAsync(key, serializedObject);

        }
        public async Task SetListCacheValueAsync<T>(string key, List<T> record,
             TimeSpan? absoluteExpireTime = null,
             TimeSpan? unusedExpireTime = null)
        {
            var db = _connectionMultiplexer.GetDatabase();

            if (record is null)
                throw new("Null can not be deserialize");

            var serializedObject = JsonConvert.SerializeObject(record);

            await db.StringSetAsync(key, serializedObject, absoluteExpireTime);
        }
        public void Dispose()
        {
            _connectionMultiplexer.Dispose();
        }
        private static long? GetExpirationInSeconds(DateTimeOffset creationTime, DateTimeOffset? absoluteExpiration, DistributedCacheEntryOptions options)
        {
            if (absoluteExpiration.HasValue && options.SlidingExpiration.HasValue)
            {
                return (long)Math.Min(
                    (absoluteExpiration.Value - creationTime).TotalSeconds,
                    options.SlidingExpiration.Value.TotalSeconds);
            }
            else if (absoluteExpiration.HasValue)
            {
                return (long)(absoluteExpiration.Value - creationTime).TotalSeconds;
            }
            else if (options.SlidingExpiration.HasValue)
            {
                return (long)options.SlidingExpiration.Value.TotalSeconds;
            }
            return null;
        }
        public Task SetCacheValueAsync<T>(string key, T record, TimeSpan absoluteExpireTime)
        {
            throw new NotImplementedException();
        }
    }
}
