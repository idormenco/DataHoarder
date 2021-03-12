using DataHoarder.Modules.Air.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using DataHoarder.Modules.Air.Core.Options;
using Microsoft.Extensions.Options;
using System;

namespace DataHoarder.Modules.Air.Core.Services
{
    internal class CachedAirQualityService : IAirQualityService
    {
        private readonly AirQualityService _airQualityService;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration;

        public CachedAirQualityService(AirQualityService airQualityService, IMemoryCache cache, IOptions<AirModuleOptions> airModuleOptions)
        {
            _airQualityService = airQualityService ?? throw new ArgumentNullException(nameof(cache));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheExpiration = TimeSpan.FromSeconds(airModuleOptions.Value.CacheExpirationInSeconds);
        }

        public async Task<IReadOnlyList<AirQualityDto>> GetAirQualityAsync()
        {
            return await _cache.GetOrCreateAsync(CacheKeys.AirQualityKey, entry =>
            {
                entry.SlidingExpiration = _cacheExpiration;
                return _airQualityService.GetAirQualityAsync();
            });
        }
    }
}
