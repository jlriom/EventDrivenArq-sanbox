using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Sandbox.BlobStorage.WriteStack.Application.Commands;
using Sandbox.BlobStorage.WriteStack.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.BlobStorage.WriteStack.Application.CommandHandlers
{
    public class CreateBlobHandler : CommandHandler<CreateBlobCommand>
    {
        private readonly IBlobUnitOfWork _blobUnitOfWork;
        private readonly IBlobRepository _blobRepository;

        public CreateBlobHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            IBlobUnitOfWork blobUnitOfWork,
            IBlobRepository blobRepository,
            ILogger<CreateBlobCommand> logger)
            : base(bus, mapper, logger)
        {
            _blobUnitOfWork = blobUnitOfWork;
            _blobRepository = blobRepository;
        }

        protected override async Task<Result> HandleEx(CreateBlobCommand command, CancellationToken cancellationToken = default)
        {
            var blob = BlobFactory.CreateFromCommand(command);
            await _blobRepository.InsertAsync(blob).ConfigureAwait(false);
            await _blobUnitOfWork.CommitAsync().ConfigureAwait(false);
            return Result.Success();
        }
    }
}