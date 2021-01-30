using Sandbox.Doc.WriteStack.Domain.Documents;

namespace Sandbox.Doc.WriteStack.Domain.Notifications
{
    public interface INotificationProvider
    {
        NotificationType GetNotificationType();
        string GetMessage(Document document);
        string GetTitle(Document document);
    }
}
