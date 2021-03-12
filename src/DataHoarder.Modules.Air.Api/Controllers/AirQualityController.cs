using System.Collections.Generic;
using System.Threading.Tasks;
using DataHoarder.Modules.Air.Core.DTO;
using DataHoarder.Modules.Air.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataHoarder.Modules.Air.Api.Controllers
{
    internal class AirQualityController : BaseController
    {
        private readonly IAirQualityService _airQualityService;

        public AirQualityController(IAirQualityService airQualityService)
        {
            _airQualityService = airQualityService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AirQualityDto>>> GetAirQualityAsync()
            => Ok(await _airQualityService.GetAirQualityAsync());
    }
}