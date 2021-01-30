using Common.Core;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Services;

namespace Sandbox.Doc.WriteStack.Infrastructure.Emails
{
    public class DocumentUpdatedSuccessFullyEmailProvider : IEmailProvider
    {
        private readonly IDocumentClientUrlProvider _documentClientUrlProvider;
        private readonly User _user;
        private readonly Document _document;

        public DocumentUpdatedSuccessFullyEmailProvider(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider)
        {
            _user = user;
            _document = document;
            _documentClientUrlProvider = documentClientUrlProvider;
        }

        public string GetSubject()
        {
            return $"[Sandbox] - Document updated: {_document.Name}";
        }

        public string GetBody()
        {
            return $"\nDocument updated: {_document.Name}\n\nLink: {_documentClientUrlProvider.GetClientUrlForDocument(_document)}";
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
