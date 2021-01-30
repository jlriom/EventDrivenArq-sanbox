using AutoMapper;
using Common.Application.Exceptions;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Data.Documents.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Infrastructure.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentsDbContext _context;
        private readonly IMapper _mapper;

        public DocumentRepository(DocumentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Document entity)
        {
            _context.Document.Remove(new Shared.Data.Documents.Core.Document
            {
                Id = entity.Id
            });
            await Task.CompletedTask;
        }

        public async Task<Document> InsertAsync(Document entity)
        {

            var doc = _mapper.Map<Shared.Data.Documents.Core.Document>(entity);
            doc.CreatedBy = entity.Created.UserId.ToString();
            doc.CreatedOn = entity.Created.On;

            await _context
                .Document
                .AddAsync(doc)
                .ConfigureAwait(false);

            return entity;
        }

        public async Task<Document> UpdateAsync(Document entity)
        {
            var docToUpdate = await _context.Document.FindAsync(entity.Id).ConfigureAwait(false);

            if (docToUpdate == null)
            {
                throw new NotFoundException();
            }

            var documentName = docToUpdate.DocumentName;
            _mapper.Map(entity, docToUpdate);
            docToUpdate.DocumentName = documentName;
            _context
                .Document
                .Update(docToUpdate);

            return await Task.FromResult(entity);
        }
    }
}
