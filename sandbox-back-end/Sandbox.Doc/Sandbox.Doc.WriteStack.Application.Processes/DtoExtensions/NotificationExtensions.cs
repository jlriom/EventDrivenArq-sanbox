using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Notifications;

namespace Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions
{
    public static class NotificationExtensions
    {
        public static NotificationDto ToDto(this Notification notification)
        {
            return new NotificationDto
            {
                Message = notification.Message,
                Title = notification.Title,
                NotificationType = (int)notification.NotificationType,
                Id = notification.Id
            };
        }

        public static Notification ToNotification(this NotificationDto notificationDto)
        {
            return new Notification
            {
                Message = notificationDto.Message,
                Title = notificationDto.Title,
                NotificationType = (NotificationType)notificationDto.NotificationType,
                Id = notificationDto.Id
            };
        }
    }
}
