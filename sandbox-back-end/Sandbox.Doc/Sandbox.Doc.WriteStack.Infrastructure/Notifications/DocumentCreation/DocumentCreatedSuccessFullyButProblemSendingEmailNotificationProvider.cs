using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentCreation
{
    public class DocumentCreatedSuccessFullyButProblemSendingEmailNotificationProvider
        : DocumentCreationNotificationProviderBase
    {
        public override NotificationType GetNotificationType()
        {
            return NotificationType.Warning;
        }

        public override string GetMessage(Document document)
        {
            return
                $"Document '{document.Name}' created successfully, but there was a problem sending an email notifying its creation";
        }
    }
}
