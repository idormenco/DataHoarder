using DataHoarder.Modules.Air.Core.Options;
using DataHoarder.Modules.Air.Core.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DataHoarder.Modules.Air.Core.BackgroundJobs
{
    internal class AirQualityCacheUpdaterBackgrounJob : IAirQualityCacheUpdaterBackgrounJob
    {
        private readonly IAirQualityProvider _airQualityProvider;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration;


        public AirQualityCacheUpdaterBackgrounJob(IAirQualityProvider airQualityProvider, IMemoryCache cache, IOptions<AirModuleOptions> airModuleOptions)
        {
            _airQualityProvider = airQualityProvider ?? throw new ArgumentNullException(nameof(airQualityProvider));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheExpiration = TimeSpan.FromSeconds(airModuleOptions.Value.CacheExpirationInSeconds);

        }

        public async Task UpdateAirQualityCacheAsync()
        {
            var values = await _airQualityProvider.GetAirQualityAsync();
            _cache.Set(CacheKeys.AirQualityKey, values, _cacheExpiration);
        }
    }
}
