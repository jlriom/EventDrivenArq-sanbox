using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class SendNotificationDocumentCreated : NotificationActivity<SendNotificationDocumentCreated, CreateDocumentState, DocumentCreatedEmailSentEvent>
    {
        public SendNotificationDocumentCreated(
            ILogger<SendNotificationDocumentCreated> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentCreatedSuccessFullyNotification())
        {
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, DocumentCreatedEmailSentEvent> context, Behavior<CreateDocumentState, DocumentCreatedEmailSentEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.ToDocument());
        }
    }
}
