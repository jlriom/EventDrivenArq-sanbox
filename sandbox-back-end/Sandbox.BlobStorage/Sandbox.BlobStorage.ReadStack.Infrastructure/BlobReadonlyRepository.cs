using Common.Data.EntityFrameworkCore;
using Sandbox.BlobStorage.ReadStack.Core;
using Sandbox.Shared.Data.Blob.Core;
using Sandbox.Shared.Data.Blob.EntityFrameworkCore;

namespace Sandbox.BlobStorage.ReadStack.Infrastructure
{
    public class BlobReadonlyRepository : ReadonlyRepository<Document, BlobDocumentDbContext>, IBlobReadonlyRepository
    {
        public BlobReadonlyRepository(BlobDocumentDbContext context) : base(context)
        {
        }
    }
}
