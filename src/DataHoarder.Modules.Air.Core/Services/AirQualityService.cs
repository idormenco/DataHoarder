using DataHoarder.Modules.Air.Core.DTO;
using DataHoarder.Modules.Air.Core.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DataHoarder.Modules.Air.Core.Services
{
    internal class AirQualityService : IAirQualityService
    {
        private readonly IAirQualityProvider _airQualityProvider;

        public AirQualityService(IAirQualityProvider airQualityProvider)
        {
            _airQualityProvider = airQualityProvider ?? throw new ArgumentNullException(nameof(airQualityProvider));
        }

        public async Task<IReadOnlyList<AirQualityDto>> GetAirQualityAsync()
        {
            var data = await _airQualityProvider.GetAirQualityAsync();

            return data.Select(x => new AirQualityDto
            {
                Value = x.Value
            }).ToList();
        }
    }
}
