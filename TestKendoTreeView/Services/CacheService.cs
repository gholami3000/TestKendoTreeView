using Microsoft.Extensions.Caching.Memory;

namespace TestKendoTreeView.Services
{
    public class CacheService
    {
        private readonly ILogger<CacheService> _logger;

        private IMemoryCache _cache;
        public CacheService(ILogger<CacheService> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public T Get<T>(object key)
        {
            return _cache.Get<T>(key);
        }

        public void Set<T>(object key, T value,TimeSpan expiration)
        {
            _cache.Set<T>(key, value, expiration); //TimeSpan.FromSeconds(90));
        }
    }
}
