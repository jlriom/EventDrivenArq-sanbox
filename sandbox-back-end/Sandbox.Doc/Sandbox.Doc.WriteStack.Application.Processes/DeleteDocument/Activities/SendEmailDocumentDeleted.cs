using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using Sandbox.Shared.Messaging.Messages.Emails;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{

    public class SendEmailDocumentDeleted : DocumentActivity<SendEmailDocumentDeleted, DeleteDocumentState, DocumentDeletedFromDbEvent>
    {
        private readonly IEmailProviderFactory _emailProviderFactory;

        public SendEmailDocumentDeleted(
            ILogger<SendEmailDocumentDeleted> logger,
            IEmailProviderFactory emailProviderFactory
            ) : base(logger)
        {
            _emailProviderFactory = emailProviderFactory;
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, DocumentDeletedFromDbEvent> context, Behavior<DeleteDocumentState, DocumentDeletedFromDbEvent> next)
        {
            var emailProvider = _emailProviderFactory
                .CreateDocumentDeletedSuccessFullyEmail(
                    context.Data.User,
                    context.Data.PayLoad.ToEmptyDocumentWithId());

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
