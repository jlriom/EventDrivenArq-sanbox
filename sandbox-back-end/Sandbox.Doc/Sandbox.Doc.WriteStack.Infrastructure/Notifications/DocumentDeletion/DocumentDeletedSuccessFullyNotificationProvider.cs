using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentDeletion
{
    public class DocumentDeletedSuccessFullyNotificationProvider : DocumentCreationNotificationProviderBase
    {
        public override NotificationType GetNotificationType()
        {
            return NotificationType.Success;
        }

        public override string GetMessage(Document document)
        {
            return
                $"Document '{document.Name}' deleted successfully!";
        }
    }
}
