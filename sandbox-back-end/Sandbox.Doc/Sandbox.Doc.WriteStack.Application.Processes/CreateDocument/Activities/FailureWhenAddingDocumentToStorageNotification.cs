using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class FailureWhenAddingDocumentToStorageNotification : NotificationActivity<FailureWhenAddingDocumentToStorageNotification, CreateDocumentState, FailureWhenAddingDocumentToStorageEvent>
    {

        public FailureWhenAddingDocumentToStorageNotification(
            ILogger<FailureWhenAddingDocumentToStorageNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentHasNotBeenCreatedDueToTechnicalErrorNotification())
        {
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, FailureWhenAddingDocumentToStorageEvent> context, Behavior<CreateDocumentState, FailureWhenAddingDocumentToStorageEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToDocument());
        }
    }
}