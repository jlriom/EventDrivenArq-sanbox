using Sandbox.BlobStorage.WriteStack.Domain;
using Sandbox.Shared.Data.Blob.Core;
using Sandbox.Shared.Data.Blob.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sandbox.BlobStorage.WriteStack.Infrastructure
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobDocumentDbContext _context;

        public BlobRepository(BlobDocumentDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Blob entity)
        {
            _context.Documents.Remove(new Document
            {
                Id = entity.Id,
                Content = entity.Content
            });
            await Task.CompletedTask;
        }

        public async Task<Blob> InsertAsync(Blob entity)
        {
            var doc = await _context.Documents.AddAsync(new Document
            {
                Id = entity.Id,
                Content = entity.Content
            }).ConfigureAwait(false);

            return new Blob
            {
                Id = doc.Entity.Id,
                Content = doc.Entity.Content
            };
        }

        public async Task<Blob> UpdateAsync(Blob entity)
        {
            var doc = _context.Documents.Update(new Document
            {
                Id = entity.Id,
                Content = entity.Content
            });

            return await Task.FromResult(new Blob
            {
                Id = doc.Entity.Id,
                Content = doc.Entity.Content
            });
        }
    }
}
