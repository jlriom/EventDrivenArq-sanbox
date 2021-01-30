using Sandbox.Doc.WriteStack.Domain.Documents;
using System;

namespace Sandbox.Doc.WriteStack.Domain.Services
{
    public interface IDocumentClientUrlProvider
    {
        Uri GetClientUrlForDocument(Document document);
    }
}
