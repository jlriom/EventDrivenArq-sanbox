using System;
using System.Threading.Tasks;

namespace Common.Application.Services.BlobStorage
{
    public interface IBlobStorageClient
    {
        Task<byte[]> Get(Guid id);
        Task Post(Guid id, byte[] content, string accessToken);
        Task Put(Guid id, byte[] content, string accessToken);
        Task Delete(Guid id, string accessToken);
    }
}
