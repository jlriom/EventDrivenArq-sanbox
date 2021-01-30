using Common.Application.Cqs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Console.ReadStack.Application.Queries;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox.Console.Api.Controllers
{
    public class ConfigurationSettingController : ApiBaseController<ConfigurationSettingController>
    {
        public ConfigurationSettingController(
            ILogger<ConfigurationSettingController> logger) : base(logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ConfigurationSettingDto>>>
            Get([FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new GetConfigurationSettingsQuery()).ConfigureAwait(false));
        }
    }
}