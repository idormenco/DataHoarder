using Microsoft.AspNetCore.Mvc;

namespace DataHoarder.Modules.Air.Api.Controllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    internal abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "air-module";
    }
}