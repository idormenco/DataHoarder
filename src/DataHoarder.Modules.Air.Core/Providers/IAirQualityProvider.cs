using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataHoarder.Modules.Air.Core.Providers
{
    internal interface IAirQualityProvider
    {
        Task<IReadOnlyList<QualityModel>> GetAirQualityAsync();
    }
}
