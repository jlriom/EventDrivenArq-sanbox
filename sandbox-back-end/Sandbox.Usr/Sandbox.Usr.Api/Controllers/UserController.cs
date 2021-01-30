using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using Sandbox.Usr.ReadStack.Application.Queries.User;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;
using Sandbox.Usr.WriteStack.Application.Commands.User;
using Sandbox.Usr.WriteStack.Application.Commands.User.Dtos;
using System;
using System.Threading.Tasks;

namespace Sandbox.Usr.Api.Controllers
{
    public class UserController : ApiBaseController<UserController>
    {
        public UserController(
            ILogger<UserController> logger) : base(logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Paging<UserDto>>>
            Get(
                int limit,
                int offset,
                [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new SearchUsersQuery(limit, offset)).ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>>
            Get(Guid id, [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new GetUserQuery(id)).ConfigureAwait(false));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            UserRequestDto userRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new CreateUserCommand(userRequestDto)).ConfigureAwait(false));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(
            Guid id,
            UserRequestDto userRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new UpdateUserCommand(id, userRequestDto)).ConfigureAwait(false));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(
            Guid id,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok(await commandDispatcher.Dispatch(new DeleteUserCommand(id)).ConfigureAwait(false));
        }
    }
}