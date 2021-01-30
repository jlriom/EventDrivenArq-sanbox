using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{
    public class FailureWhenDeletingDocumentFromDbNotification : NotificationActivity<FailureWhenDeletingDocumentFromDbNotification, DeleteDocumentState, FailureWhenDeletingDocumentFromDbEvent>
    {
        public FailureWhenDeletingDocumentFromDbNotification(
            ILogger<FailureWhenDeletingDocumentFromDbNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentHasNotBeenDeletedDueToTechnicalErrorNotification())
        {
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, FailureWhenDeletingDocumentFromDbEvent> context, Behavior<DeleteDocumentState, FailureWhenDeletingDocumentFromDbEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToEmptyDocumentWithId());
        }
    }
}
