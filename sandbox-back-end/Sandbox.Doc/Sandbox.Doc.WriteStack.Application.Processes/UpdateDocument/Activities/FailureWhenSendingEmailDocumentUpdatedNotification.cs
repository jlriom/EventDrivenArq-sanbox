using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{
    public class FailureWhenSendingEmailDocumentUpdatedNotification : NotificationActivity<FailureWhenSendingEmailDocumentUpdatedNotification, UpdateDocumentState, FailureWhenSendingEmailDocumentUpdatedEvent>
    {
        public FailureWhenSendingEmailDocumentUpdatedNotification(
            ILogger<FailureWhenSendingEmailDocumentUpdatedNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentUpdatedSuccessFullyButProblemSendingEmailNotification())
        {
        }

        public override Task Execute(BehaviorContext<UpdateDocumentState, FailureWhenSendingEmailDocumentUpdatedEvent> context, Behavior<UpdateDocumentState, FailureWhenSendingEmailDocumentUpdatedEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToDocument());
        }
    }
}
