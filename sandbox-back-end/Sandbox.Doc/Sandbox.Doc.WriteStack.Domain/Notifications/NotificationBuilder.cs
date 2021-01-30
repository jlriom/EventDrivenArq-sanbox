namespace Sandbox.Doc.WriteStack.Domain.Notifications
{
    public class NotificationBuilder
    {
        private readonly Notification _notification;
        public NotificationBuilder()
        {
            _notification = new Notification();
        }

        public NotificationBuilder SetNotificationType(NotificationType notificationType)
        {
            _notification.NotificationType = notificationType;
            return this;
        }

        public NotificationBuilder SetMessage(string message)
        {
            _notification.Message = message;
            return this;
        }

        public NotificationBuilder SetTitle(string title)
        {
            _notification.Title = title;
            return this;
        }

        public Notification Build()
        {
            return _notification;
        }
    }
}
