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
    public class UpdateDocumentHandler : CommandHandler<UpdateDocumentCommand>
    {
        private readonly IClock _clock;
        private readonly MassTransit.IBus _massTransitBus;
        private readonly IMessageDataRepository _messageDataRepository;

        public UpdateDocumentHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            IClock clock,
            MassTransit.IBus massTransitBus,
            IMessageDataRepository messageDataRepository,
            ILogger<UpdateDocumentCommand> logger)
            : base(bus, mapper, logger)
        {
            _massTransitBus = massTransitBus;
            _messageDataRepository = messageDataRepository;
            _clock = clock;
        }

        protected override async Task<Result> HandleEx(UpdateDocumentCommand command, CancellationToken cancellationToken = default)
        {

            var doc = new DocumentFactory(Bus.User.Id, _clock.Now).CreateFromCommand(command);
            doc.Validate("Error updating document");

            var massTransitCommand = await new CommandFactory().CreateUpdateDocumentCommand(doc, _messageDataRepository);
            await _massTransitBus.Send(massTransitCommand, cancellationToken).ConfigureAwait(false);

            return Result.Success();
        }
    }
}