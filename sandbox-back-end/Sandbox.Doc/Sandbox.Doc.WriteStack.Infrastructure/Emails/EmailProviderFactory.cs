using Common.Core;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Services;

namespace Sandbox.Doc.WriteStack.Infrastructure.Emails
{
    public class EmailProviderFactory : IEmailProviderFactory
    {
        public IEmailProvider CreateDocumentCreatedSuccessFullyEmail(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider)
        {
            return new DocumentCreatedSuccessFullyEmailProvider(user, document, documentClientUrlProvider);
        }

        public IEmailProvider CreateDocumentDeletedSuccessFullyEmail(User user, Document document)
        {
            return new DocumentDeletedSuccessFullyEmailProvider(user, document);
        }

        public IEmailProvider CreateDocumentUpdatedSuccessFullyEmail(User user, Document document, IDocumentClientUrlProvider documentClientUrlProvider)
        {
            return new DocumentUpdatedSuccessFullyEmailProvider(user, document, documentClientUrlProvider);
        }
    }


}
