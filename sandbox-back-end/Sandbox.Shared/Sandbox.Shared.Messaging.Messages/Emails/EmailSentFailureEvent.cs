using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Emails
{
    public class EmailSentFailureEvent : MessageBase<EmailSendingFailure>
    {
        public EmailSentFailureEvent(Guid correlationId, User user, EmailSendingFailure payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
