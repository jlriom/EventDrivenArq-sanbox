using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentCreation
{
    public class DocumentHasNotBeenCreatedDueToTechnicalErrorNotificationProvider
        : DocumentCreationNotificationProviderBase
    {
        public override NotificationType GetNotificationType()
        {
            return NotificationType.Error;
        }

        public override string GetMessage(Document document)
        {
            return
                $"Document '{document.Name}' not created due to a technical issue. Please contact to an administrator";
        }
    }
}
