using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{
    public class FailureWhenDeletingDocumentFromStorageNotification : NotificationActivity<FailureWhenDeletingDocumentFromStorageNotification, DeleteDocumentState, FailureWhenDeletingDocumentFromStorageEvent>
    {
        public FailureWhenDeletingDocumentFromStorageNotification(
            ILogger<FailureWhenDeletingDocumentFromStorageNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentHasNotBeenDeletedDueToTechnicalErrorNotification())
        {
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, FailureWhenDeletingDocumentFromStorageEvent> context, Behavior<DeleteDocumentState, FailureWhenDeletingDocumentFromStorageEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToEmptyDocumentWithId());
        }
    }
}