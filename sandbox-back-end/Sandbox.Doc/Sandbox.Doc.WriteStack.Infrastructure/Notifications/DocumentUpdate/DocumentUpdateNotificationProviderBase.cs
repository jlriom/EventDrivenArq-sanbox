using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentUpdate
{
    public abstract class DocumentUpdateNotificationProviderBase : INotificationProvider
    {
        public abstract NotificationType GetNotificationType();

        public abstract string GetMessage(Document document);

        public string GetTitle(Document document)
        {
            return "Document update";
        }
    }
}
