using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.Api.Dtos;
using Sandbox.Doc.ReadStack.Application.Queries;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using Sandbox.Doc.WriteStack.Application.Commands;
using Sandbox.Doc.WriteStack.Application.Commands.Dtos;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using System;
using System.Threading.Tasks;

namespace Sandbox.Doc.Api.Controllers
{
    public class DocumentController : ApiBaseController<DocumentController>
    {
        public DocumentController(
            ILogger<DocumentController> logger) : base(logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Paging<DocumentPropertiesDto>>>
            Get(
                int limit,
                int offset,
                [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new SearchDocumentsQuery(limit, offset)).ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DocumentPropertiesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DocumentPropertiesDto>>
            Get(Guid id, [FromServices] IQueryDispatcher queryDispatcher)
        {
            return Ok(await queryDispatcher.Dispatch(new DocumentPropertiesQuery(id)).ConfigureAwait(false));
        }

        [HttpGet("{id}/content")]
        [ProducesResponseType(typeof(DocumentContentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DocumentContentDto>>
            GetContent(Guid id, [FromServices] IQueryDispatcher queryDispatcher)
        {
            var documentContent = await queryDispatcher.Dispatch(new DocumentContentQuery(id)).ConfigureAwait(false);
            return Ok(documentContent);
        }

        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            [FromForm] DocumentRequestDto documentDto,
            [FromServices] IMapper mapper,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok((await commandDispatcher.Dispatch(new CreateDocumentCommand(
                documentDto.Name,
                documentDto.DocumentStatusId,
                mapper.Map<FileDto>(documentDto.File))).ConfigureAwait(false)).IsSuccess);
        }

        [HttpPut("{id}")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(
            Guid id,
            [FromForm] DocumentRequestDto documentRequestDto,
            [FromServices] IMapper mapper,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok((await commandDispatcher.Dispatch(new UpdateDocumentCommand(
                id,
                documentRequestDto.Name,
                documentRequestDto.DocumentStatusId,
                mapper.Map<FileDto>(documentRequestDto.File))).ConfigureAwait(false)).IsSuccess);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Patch(
            Guid id,
            DocumentPropertiesRequestDto documentPropertiesRequestDto,
            [FromServices] ICommandDispatcher commandDispatcher)
        {
            return Ok((await commandDispatcher.Dispatch(new UpdateDocumentPropertiesCommand(
                id,
                documentPropertiesRequestDto.Name,
                documentPropertiesRequestDto.DocumentStatusId)).ConfigureAwait(false)).IsSuccess);
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
            return Ok((await commandDispatcher.Dispatch(new DeleteDocumentCommand(id)).ConfigureAwait(false)).IsSuccess);
        }
    }
}