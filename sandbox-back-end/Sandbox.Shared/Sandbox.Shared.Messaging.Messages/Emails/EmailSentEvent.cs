using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Emails
{
    public class EmailSentEvent : MessageBase<Guid>
    {
        public EmailSentEvent(Guid correlationId, User user, Guid payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
