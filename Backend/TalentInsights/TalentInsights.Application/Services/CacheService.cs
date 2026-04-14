using Microsoft.Extensions.Caching.Memory;
using TalentInsights.Application.Interfaces.Services;

namespace TalentInsights.Application.Services
{
    public class CacheService(IMemoryCache memoryCache) : ICacheService
    {
        public T Create<T>(string key, TimeSpan expiration, T value)
        {
            try
            {
                var create = memoryCache.GetOrCreate(key, (factory) =>
                {
                    factory.SlidingExpiration = expiration;
                    return value;
                });

                return create ?? throw new Exception("No se pudo establecer la cache");
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(string key)
        {
            try
            {
                memoryCache.Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T? Get<T>(string key)
        {
            try
            {
                return memoryCache.Get<T>(key);
            }
            catch
            {
                throw;
            }
        }
    }
}
