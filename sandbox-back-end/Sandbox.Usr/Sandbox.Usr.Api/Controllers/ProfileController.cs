using Common.Application.Cqs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using Sandbox.Usr.ReadStack.Application.Queries.Profile;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;
using Sandbox.Usr.WriteStack.Application.Commands.Profile;
using Sandbox.Usr.WriteStack.Application.Commands.Profile.Dtos;
using System.Threading.Tasks;

namespace Sandbox.Usr.Api.Controllers
{
    public class ProfileController : ApiBaseController<ProfileController>
    {
        public ProfileController(
            ILogger<ProfileController> logger) : base(logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProfileRequestDto>>
            Get([FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new GetProfileQuery()).ConfigureAwait(false));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            ProfileRequestDto profileRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new CreateMyProfileCommand(profileRequestDto)).ConfigureAwait(false));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(
            ProfileRequestDto profileRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new UpdateMyProfileCommand(profileRequestDto)).ConfigureAwait(false));
        }

        [HttpPost("deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new DeactivateMyProfileCommand()).ConfigureAwait(false));
        }
    }
}