using System.Threading.Tasks;

namespace Common.Data.Core
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
