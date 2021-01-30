using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Services;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using Sandbox.Shared.Messaging.Messages.Emails;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{

    public class SendEmailDocumentUpdated : DocumentActivity<SendEmailDocumentUpdated, UpdateDocumentState, DocumentUpdatedInDbEvent>
    {
        private readonly IEmailProviderFactory _emailProviderFactory;
        private readonly IDocumentClientUrlProvider _documentClientUrlProvider;

        public SendEmailDocumentUpdated(
            ILogger<SendEmailDocumentUpdated> logger,
            IEmailProviderFactory emailProviderFactory,
            IDocumentClientUrlProvider documentClientUrlProvider
        ) : base(logger)
        {
            _emailProviderFactory = emailProviderFactory;
            _documentClientUrlProvider = documentClientUrlProvider;
        }

        public override Task Execute(BehaviorContext<UpdateDocumentState, DocumentUpdatedInDbEvent> context, Behavior<UpdateDocumentState, DocumentUpdatedInDbEvent> next)
        {
            var emailProvider = _emailProviderFactory
                .CreateDocumentCreatedSuccessFullyEmail(
                    context.Data.User,
                    context.Data.PayLoad.ToDocument(),
                    _documentClientUrlProvider);

            var emailDto = new EmailBuilder()
                .SetTo(emailProvider.GetTo())
                .SetCc(emailProvider.GetCc())
                .SetSubject(emailProvider.GetSubject())
                .SetBody(emailProvider.GetBody())
                .Build()
                .ToDto();

            var sendEmailCommand = new SendEmailCommand(context.Data.CorrelationId, emailDto);

            context.Send(sendEmailCommand).Wait();

            return next.Execute(context);
        }
    }
}
