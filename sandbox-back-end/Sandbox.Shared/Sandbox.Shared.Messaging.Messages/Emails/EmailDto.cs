using System;

namespace Sandbox.Shared.Messaging.Messages.Emails
{
    public class EmailDto
    {
        public Guid Id { get; set; }
        public string[] To { get; set; }
        public string[] Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailDto()
        {
            Id = Guid.NewGuid();
            To = new string[0];
            Cc = new string[0];
        }
    }
}
