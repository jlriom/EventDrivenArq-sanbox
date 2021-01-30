namespace Sandbox.Doc.WriteStack.Domain.Emails
{
    public class EmailBuilder
    {
        private readonly Email _email;

        public EmailBuilder()
        {
            _email = new Email();
        }

        public EmailBuilder SetTo(string[] to)
        {
            _email.To = to;
            return this;
        }

        public EmailBuilder SetCc(string[] cc)
        {
            _email.Cc = cc;
            return this;
        }

        public EmailBuilder SetSubject(string subject)
        {
            _email.Subject = subject;
            return this;
        }

        public EmailBuilder SetBody(string body)
        {
            _email.Body = body;
            return this;
        }

        public Email Build()
        {
            return _email;
        }

    }
}
