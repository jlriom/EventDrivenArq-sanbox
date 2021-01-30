using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.CommandHandlers
{
    public class DeleteDocumentHandler : CommandHandler<DeleteDocumentCommand>
    {
        private readonly MassTransit.IBus _massTransitBus;

        public DeleteDocumentHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            MassTransit.IBus massTransitBus,
            ILogger<DeleteDocumentCommand> logger)
            : base(bus, mapper, logger)
        {
            _massTransitBus = massTransitBus;
        }

        protected override async Task<Result> HandleEx(DeleteDocumentCommand command, CancellationToken cancellationToken = default)
        {
            var doc = new DocumentFactory(Bus.User.Id).CreateFromCommand(command);
            doc.Validate("Error deleting document");

            var massTransitCommand = new CommandFactory().CreateDeleteDocumentCommand(doc);
            await _massTransitBus.Send(massTransitCommand, cancellationToken).ConfigureAwait(false);

            return Result.Success();
        }
    }
}