using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{

    public class FailureWhenSendingEmailDocumentCreatedNotification : NotificationActivity<FailureWhenSendingEmailDocumentCreatedNotification, CreateDocumentState, FailureWhenSendingEmailDocumentCreatedEvent>
    {
        public FailureWhenSendingEmailDocumentCreatedNotification(
            ILogger<FailureWhenSendingEmailDocumentCreatedNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentCreatedSuccessFullyButProblemSendingEmailNotification())
        {
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, FailureWhenSendingEmailDocumentCreatedEvent> context, Behavior<CreateDocumentState, FailureWhenSendingEmailDocumentCreatedEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToDocument());
        }
    }
}
