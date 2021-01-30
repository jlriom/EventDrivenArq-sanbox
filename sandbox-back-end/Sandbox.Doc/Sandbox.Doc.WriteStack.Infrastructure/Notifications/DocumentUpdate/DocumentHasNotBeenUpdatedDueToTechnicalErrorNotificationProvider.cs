using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentUpdate
{
    public class DocumentHasNotBeenUpdatedDueToTechnicalErrorNotificationProvider : DocumentUpdateNotificationProviderBase
    {
        public override NotificationType GetNotificationType()
        {
            return NotificationType.Error;
        }

        public override string GetMessage(Document document)
        {
            return
                $"Document '{document.Name}' not updated due to a technical issue. Please contact to an administrator";
        }
    }
}
