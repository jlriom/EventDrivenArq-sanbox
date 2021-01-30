using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Domain.Documents
{
    public interface IDocumentRepository
    {
        Task DeleteAsync(Document entity);
        Task<Document> InsertAsync(Document entity);
        Task<Document> UpdateAsync(Document entity);
    }
}
