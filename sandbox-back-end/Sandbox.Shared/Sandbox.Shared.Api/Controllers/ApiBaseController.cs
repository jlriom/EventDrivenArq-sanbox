using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sandbox.Shared.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiBaseController<T> : ControllerBase where T : ControllerBase
    {
        protected readonly ILogger<T> Logger;

        protected ApiBaseController(ILogger<T> logger)
        {
            Logger = logger;

        }
    }
}