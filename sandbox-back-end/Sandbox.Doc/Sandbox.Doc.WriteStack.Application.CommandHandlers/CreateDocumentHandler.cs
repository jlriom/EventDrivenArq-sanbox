using AutoMapper;
using Common.Application.Clock;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using MassTransit;
using MassTransit.MessageData;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.CommandHandlers
{
    public class CreateDocumentHandler : CommandHandler<CreateDocumentCommand>
    {
        private readonly IClock _clock;
        private readonly MassTransit.IBus _massTransitBus;
        private readonly IMessageDataRepository _messageDataRepository;

        public CreateDocumentHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            IClock clock,
            MassTransit.IBus massTransitBus,
            IMessageDataRepository messageDataRepository,
            ILogger<CreateDocumentCommand> logger)
            : base(bus, mapper, logger)
        {

            _messageDataRepository = messageDataRepository;
            _massTransitBus = massTransitBus;
            _clock = clock;
        }

        protected override async Task<Result> HandleEx(CreateDocumentCommand command, CancellationToken cancellationToken = default)
        {
            var docId = NewId.NextGuid();

            var doc = new DocumentFactory(Bus.User.Id, _clock.Now).CreateFromCommand(docId, command);
            doc.Validate("Error adding a new document");

            var massTransitCommand = await new CommandFactory().CreateCreateDocumentCommand(doc, _messageDataRepository);
            await _massTransitBus.Send(massTransitCommand, cancellationToken).ConfigureAwait(false);

            return Result.Success();
        }
    }
}