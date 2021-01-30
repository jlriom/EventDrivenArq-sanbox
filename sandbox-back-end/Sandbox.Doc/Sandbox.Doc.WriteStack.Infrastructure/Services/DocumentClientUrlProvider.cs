using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Services;
using System;

namespace Sandbox.Doc.WriteStack.Infrastructure.Services
{
    public class DocumentClientUrlProvider : IDocumentClientUrlProvider
    {
        private readonly string _clientUrl;

        public DocumentClientUrlProvider(string clientUrl)
        {
            _clientUrl = clientUrl;
        }

        public Uri GetClientUrlForDocument(Document document)
        {
            return new Uri($"{_clientUrl}/document/{document.Id}/details");
        }
    }
}
