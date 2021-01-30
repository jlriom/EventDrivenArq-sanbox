using Common.Data.EntityFrameworkCore;
using Sandbox.Doc.ReadStack.Core;
using Sandbox.Shared.Data.Documents.Core;
using Sandbox.Shared.Data.Documents.EntityFrameworkCore;

namespace Sandbox.Doc.ReadStack.Infrastructure
{
    public class DocumentReadonlyRepository : ReadonlyRepository<Document, DocumentsDbContext>, IDocumentReadonlyRepository
    {
        public DocumentReadonlyRepository(DocumentsDbContext context) : base(context)
        {
        }
    }
}
