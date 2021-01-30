using Common.Core;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Services;

namespace Sandbox.Doc.WriteStack.Infrastructure.Emails
{
    public class DocumentCreatedSuccessFullyEmailProvider : IEmailProvider
    {
        private readonly IDocumentClientUrlProvider _documentClientUrlProvider;
        private readonly User _user;
        private readonly Document _document;

        public DocumentCreatedSuccessFullyEmailProvider(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider)
        {
            _user = user;
            _document = document;
            _documentClientUrlProvider = documentClientUrlProvider;
        }

        public string GetSubject()
        {
            return $"[Sandbox] - New Document created: {_document.Name}";
        }

        public string GetBody()
        {
            return $"\nNew Document created: {_document.Name}\n\nLink: {_documentClientUrlProvider.GetClientUrlForDocument(_document)}";
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
