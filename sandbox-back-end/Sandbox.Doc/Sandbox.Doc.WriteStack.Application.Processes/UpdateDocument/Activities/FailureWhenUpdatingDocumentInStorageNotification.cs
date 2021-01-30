using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{
    public class FailureWhenUpdatingDocumentInStorageNotification : NotificationActivity<FailureWhenUpdatingDocumentInStorageNotification, UpdateDocumentState, FailureWhenUpdatingDocumentInStorageEvent>
    {
        public FailureWhenUpdatingDocumentInStorageNotification(
            ILogger<FailureWhenUpdatingDocumentInStorageNotification> logger,
            INotificationProviderFactory notificationProviderFactory
        ) : base(logger, notificationProviderFactory.CreateDocumentHasNotBeenUpdatedDueToTechnicalErrorNotification())
        {
        }

        public override Task Execute(BehaviorContext<UpdateDocumentState, FailureWhenUpdatingDocumentInStorageEvent> context, Behavior<UpdateDocumentState, FailureWhenUpdatingDocumentInStorageEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToDocument());
        }
    }
}