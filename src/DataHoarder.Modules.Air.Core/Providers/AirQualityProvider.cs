using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataHoarder.Modules.Air.Core.Providers
{
    internal class AirQualityProvider : IAirQualityProvider
    {
        public async Task<IReadOnlyList<QualityModel>> GetAirQualityAsync()
        {
            await Task.CompletedTask;

            return new List<QualityModel>() {
                new() { Value =1 },
                new() { Value =2 },
                new() { Value =3 },
                new() { Value =4 }
            };
        }
    }
}
