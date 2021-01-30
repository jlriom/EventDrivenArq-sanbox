using Common.Core;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Emails;

namespace Sandbox.Doc.WriteStack.Infrastructure.Emails
{
    public class DocumentDeletedSuccessFullyEmailProvider : IEmailProvider
    {
        private readonly User _user;
        private readonly Document _document;

        public DocumentDeletedSuccessFullyEmailProvider(User user, Document document)
        {
            _user = user;
            _document = document;
        }

        public string GetSubject()
        {
            return $"[Sandbox] - Document deleted: {_document.Name}";
        }

        public string GetBody()
        {
            return $"\nDocument Deleted: {_document.Name}";
        }

        public string[] GetTo()
        {
            return new[] { _user.Email };
        }

        public string[] GetCc()
        {
            return new string[0];
        }
    }
}
