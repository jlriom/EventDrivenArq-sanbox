using Common.Core;
using Sandbox.Shared.Messaging.Messages.Documents;
using System;

namespace Sandbox.Shared.Messaging.Messages.Notifications
{
    public class NotificationSentFailureEvent : MessageBase<Failure<DocumentDto>>
    {
        public NotificationSentFailureEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
