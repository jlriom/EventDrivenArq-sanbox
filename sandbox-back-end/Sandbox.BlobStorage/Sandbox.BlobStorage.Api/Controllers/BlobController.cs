using Common.Application.Cqs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.BlobStorage.Api.Dtos;
using Sandbox.BlobStorage.ReadStack.Application.Queries;
using Sandbox.BlobStorage.WriteStack.Application.Commands;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using System;
using System.Threading.Tasks;

namespace Sandbox.BlobStorage.Api.Controllers
{
    public class BlobController : ApiBaseController<BlobController>
    {
        public BlobController(
            ILogger<BlobController> logger) : base(logger)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<byte[]>>
            Get(Guid id, [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new GetBlobQuery(id)).ConfigureAwait(false));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            CreateBlobRequestDto createBlobRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok((await commandDispatcher.Dispatch(new CreateBlobCommand(createBlobRequestDto.Id, createBlobRequestDto.Blob)).ConfigureAwait(false)).IsSuccess);
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
            [FromBody] UpdateBlobRequestDto updateBlobRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok((await commandDispatcher.Dispatch(new UpdateBlobCommand(id, updateBlobRequestDto.Blob)).ConfigureAwait(false)).IsSuccess);
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
            return Ok((await commandDispatcher.Dispatch(new DeleteBlobCommand(id)).ConfigureAwait(false)).IsSuccess);
        }
    }
}