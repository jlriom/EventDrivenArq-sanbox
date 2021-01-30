using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Notifications
{
    public class NotificationSentEvent : MessageBase<Guid>
    {
        public NotificationSentEvent(Guid correlationId, User user, Guid payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
