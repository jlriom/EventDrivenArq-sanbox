using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Common.Application.Services.BlobStorage;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.ReadStack.Application.Queries;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.ReadStack.Application.QueryHandlers
{
    public class DocumentContentQueryHandler : QueryHandler<DocumentContentQuery, DocumentContentDto>
    {
        private readonly IBlobStorageClient _blobStorageClient;

        public DocumentContentQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            IBlobStorageClient blobStorageClient,
            ILogger<DocumentContentQuery> logger) : base(bus, mapper, logger)
        {
            _blobStorageClient = blobStorageClient;
        }

        protected override async Task<DocumentContentDto> HandleEx(
            DocumentContentQuery query, CancellationToken cancellationToken = default)
        {
            var id = query.Id;
            var content = await _blobStorageClient.Get(id);
            return new DocumentContentDto(id, content);
        }
    }
}