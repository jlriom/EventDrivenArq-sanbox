using Common.Core;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Services;

namespace Sandbox.Doc.WriteStack.Domain.Emails
{
    public interface IEmailProviderFactory
    {

        IEmailProvider CreateDocumentCreatedSuccessFullyEmail(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider);

        IEmailProvider CreateDocumentDeletedSuccessFullyEmail(User user, Document document);

        IEmailProvider CreateDocumentUpdatedSuccessFullyEmail(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider);
    }
}
