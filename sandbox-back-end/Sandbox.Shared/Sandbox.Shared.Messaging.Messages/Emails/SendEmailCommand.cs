using System;

namespace Sandbox.Shared.Messaging.Messages.Emails
{
    public class SendEmailCommand : MessageBase<EmailDto>
    {

        public SendEmailCommand(Guid correlationId, EmailDto payLoad) : base(correlationId, payLoad)
        {
        }
    }
}
