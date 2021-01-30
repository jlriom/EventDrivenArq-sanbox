using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{

    public class FailureWhenSendingEmailDocumentDeletedNotification : NotificationActivity<FailureWhenSendingEmailDocumentDeletedNotification, DeleteDocumentState, FailureWhenSendingEmailDocumentDeletedEvent>
    {

        public FailureWhenSendingEmailDocumentDeletedNotification(
            ILogger<FailureWhenSendingEmailDocumentDeletedNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentDeletedSuccessFullyButProblemSendingEmailNotification())
        {
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, FailureWhenSendingEmailDocumentDeletedEvent> context, Behavior<DeleteDocumentState, FailureWhenSendingEmailDocumentDeletedEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToEmptyDocumentWithId());
        }
    }
}
