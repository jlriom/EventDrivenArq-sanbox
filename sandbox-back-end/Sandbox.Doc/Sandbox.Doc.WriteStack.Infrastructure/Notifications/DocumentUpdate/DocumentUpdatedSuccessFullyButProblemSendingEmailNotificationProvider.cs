using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentUpdate
{
    public class DocumentUpdatedSuccessFullyButProblemSendingEmailNotificationProvider : DocumentUpdateNotificationProviderBase
    {
        public override NotificationType GetNotificationType()
        {
            return NotificationType.Warning;
        }

        public override string GetMessage(Document document)
        {
            return
                $"Document '{document.Name}' updated successfully, but there was a problem sending an email notifying its creation";
        }
    }
}
