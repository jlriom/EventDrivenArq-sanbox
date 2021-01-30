using System;

namespace Sandbox.Shared.Messaging.Messages.Emails
{
    public class EmailSendingFailure
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public EmailSendingFailure(Guid id, string message, string details)
        {
            Id = id;
            Message = message;
            Details = details;
        }
    }
}
