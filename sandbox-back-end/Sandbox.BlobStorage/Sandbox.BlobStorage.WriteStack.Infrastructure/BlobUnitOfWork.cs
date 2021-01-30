using Sandbox.BlobStorage.WriteStack.Domain;
using Sandbox.Shared.Data.Blob.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sandbox.BlobStorage.WriteStack.Infrastructure
{
    public class BlobUnitOfWork : IBlobUnitOfWork
    {
        private readonly BlobDocumentDbContext _context;
        public BlobUnitOfWork(BlobDocumentDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 1;
        }
    }
}
