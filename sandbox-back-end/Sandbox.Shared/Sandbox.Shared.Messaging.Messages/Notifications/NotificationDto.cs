using System;

namespace Sandbox.Shared.Messaging.Messages.Notifications
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public int NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
