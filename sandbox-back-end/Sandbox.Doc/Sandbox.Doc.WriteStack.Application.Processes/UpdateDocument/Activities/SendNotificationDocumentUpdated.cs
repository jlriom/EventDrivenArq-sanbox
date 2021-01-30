using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{
    public class SendNotificationDocumentUpdated : NotificationActivity<SendNotificationDocumentUpdated, UpdateDocumentState, DocumentUpdatedEmailSentEvent>
    {

        public SendNotificationDocumentUpdated(
            ILogger<SendNotificationDocumentUpdated> logger,
            INotificationProviderFactory notificationProviderFactory
        ) : base(logger, notificationProviderFactory.CreateDocumentCreatedSuccessFullyNotification())
        {
        }

        public override Task Execute(BehaviorContext<UpdateDocumentState, DocumentUpdatedEmailSentEvent> context, Behavior<UpdateDocumentState, DocumentUpdatedEmailSentEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.ToDocument());
        }
    }
}
