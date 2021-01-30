using AutoMapper;
using Common.Application.Clock;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Commands;
using Sandbox.Doc.WriteStack.Domain.Documents;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.CommandHandlers
{
    public class UpdateDocumentPropertiesHandler : CommandHandler<UpdateDocumentPropertiesCommand>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentUnitOfWork _documentUnitOfWork;
        private readonly IClock _clock;

        public UpdateDocumentPropertiesHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            IClock clock,
            IDocumentRepository documentRepository,
            IDocumentUnitOfWork documentUnitOfWork,
            ILogger<UpdateDocumentPropertiesCommand> logger)
            : base(bus, mapper, logger)
        {
            _clock = clock;
            _documentUnitOfWork = documentUnitOfWork;
            _documentRepository = documentRepository;
        }

        protected override async Task<Result> HandleEx(UpdateDocumentPropertiesCommand command, CancellationToken cancellationToken = default)
        {
            await _documentRepository.UpdateAsync(new DocumentFactory(Bus.User.Id, _clock.Now).CreateFromCommand(command))
                .ConfigureAwait(false);

            await _documentUnitOfWork.CommitAsync().ConfigureAwait(false);

            return Result.Success();
        }
    }
}