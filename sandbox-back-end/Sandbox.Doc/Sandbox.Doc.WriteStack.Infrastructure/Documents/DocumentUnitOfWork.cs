using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Data.Documents.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Infrastructure.Documents
{
    public class DocumentUnitOfWork : IDocumentUnitOfWork
    {
        private readonly DocumentsDbContext _context;
        public DocumentUnitOfWork(DocumentsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 1;
        }
    }
}
