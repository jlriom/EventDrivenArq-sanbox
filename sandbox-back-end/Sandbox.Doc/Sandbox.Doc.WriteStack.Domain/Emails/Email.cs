using System;

namespace Sandbox.Doc.WriteStack.Domain.Emails
{
    public class Email
    {
        public Guid Id { get; set; }
        public string[] To { get; set; }
        public string[] Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email()
        {
            Id = Guid.NewGuid();
            To = new string[0];
            Cc = new string[0];
        }
    }
}
