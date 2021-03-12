using DataHoarder.Modules.Air.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataHoarder.Modules.Air.Core.Services
{
    public interface IAirQualityService
    {
        Task<IReadOnlyList<AirQualityDto>> GetAirQualityAsync();
    }
}
