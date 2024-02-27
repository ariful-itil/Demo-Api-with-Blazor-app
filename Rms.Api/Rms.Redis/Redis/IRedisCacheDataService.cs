namespace Redis
{
    public interface IRedisCacheDataService
    {
        Task<T> GetCacheValueAsync<T>(string key);

        Task SetCacheValueAsyn<T>(string key, T record, TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null);

        Task SetListCacheValueAsync<T>(string key, List<T> record, TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null);

        Task SetCacheValueAsync<T>(string key, T record, TimeSpan absoluteExpireTime);

        Task<List<T>> GetList<T>(string key);
    }
}
