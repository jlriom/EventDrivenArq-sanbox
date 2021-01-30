using System;

namespace Sandbox.Doc.WriteStack.Domain.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
