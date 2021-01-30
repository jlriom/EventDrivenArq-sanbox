using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Common.Application.Exceptions;
using Microsoft.Extensions.Logging;
using Sandbox.BlobStorage.ReadStack.Application.Queries;
using Sandbox.BlobStorage.ReadStack.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.BlobStorage.ReadStack.Application.QueryHandlers
{
    public class GetBlobQueryHandler : QueryHandler<GetBlobQuery, byte[]>
    {
        private readonly IBlobReadonlyRepository _blobReadonlyRepository;

        public GetBlobQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            IBlobReadonlyRepository blobReadonlyRepository,
            ILogger<GetBlobQuery> logger) : base(bus, mapper, logger)
        {
            _blobReadonlyRepository = blobReadonlyRepository;
        }

        protected override async Task<byte[]> HandleEx(
            GetBlobQuery query, CancellationToken cancellationToken = default)
        {
            var id = query.Id;
            var blob = await _blobReadonlyRepository.FindAsync(id);
            if (blob.HasNoValue)
            {
                throw new NotFoundException();
            }
            return blob.Value.Content;
        }
    }
}