using System;

namespace Sandbox.Shared.Messaging.Messages.Notifications
{
    public class SendNotificationCommand : MessageBase<NotificationDto>
    {
        public SendNotificationCommand(Guid correlationId, NotificationDto payLoad) : base(correlationId, payLoad)
        {
        }
    }
}
