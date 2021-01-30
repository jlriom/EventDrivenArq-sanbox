using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Console.ReadStack.Application.Queries;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using System.Threading.Tasks;

namespace Sandbox.Console.Api.Controllers
{
    public class LogController : ApiBaseController<LogController>
    {
        public LogController(
            ILogger<LogController> logger) : base(logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Paging<LogEntryDto>>>
            Get(
                int limit,
                int offset,
                [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new GetLogsQuery(limit, offset)).ConfigureAwait(false));
        }
    }
}