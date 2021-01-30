using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{
    public class SendNotificationDocumentDeleted : NotificationActivity<SendNotificationDocumentDeleted, DeleteDocumentState, DocumentDeletedEmailSentEvent>
    {
        public SendNotificationDocumentDeleted(
            ILogger<SendNotificationDocumentDeleted> logger,
            INotificationProviderFactory notificationProviderFactory
        ) : base(logger, notificationProviderFactory.CreateDocumentCreatedSuccessFullyNotification())
        {
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, DocumentDeletedEmailSentEvent> context, Behavior<DeleteDocumentState, DocumentDeletedEmailSentEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.ToEmptyDocumentWithId());
        }
    }
}
