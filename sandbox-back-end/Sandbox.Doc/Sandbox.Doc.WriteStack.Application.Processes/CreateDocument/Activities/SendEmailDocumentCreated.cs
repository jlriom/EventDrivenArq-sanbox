using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Services;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using Sandbox.Shared.Messaging.Messages.Emails;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{

    public class SendEmailDocumentCreated : DocumentActivity<SendEmailDocumentCreated, CreateDocumentState, DocumentAddedToDbEvent>
    {
        private readonly IEmailProviderFactory _emailProviderFactory;
        private readonly IDocumentClientUrlProvider _documentClientUrlProvider;

        public SendEmailDocumentCreated(
            ILogger<SendEmailDocumentCreated> logger,
            IEmailProviderFactory emailProviderFactory,
            IDocumentClientUrlProvider documentClientUrlProvider
            ) : base(logger)
        {
            _emailProviderFactory = emailProviderFactory;
            _documentClientUrlProvider = documentClientUrlProvider;
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, DocumentAddedToDbEvent> context, Behavior<CreateDocumentState, DocumentAddedToDbEvent> next)
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
