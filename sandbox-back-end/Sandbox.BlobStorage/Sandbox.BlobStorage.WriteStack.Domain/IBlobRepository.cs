using System.Threading.Tasks;

namespace Sandbox.BlobStorage.WriteStack.Domain
{
    public interface IBlobRepository
    {
        Task DeleteAsync(Blob entity);
        Task<Blob> InsertAsync(Blob entity);
        Task<Blob> UpdateAsync(Blob entity);
    }
}
