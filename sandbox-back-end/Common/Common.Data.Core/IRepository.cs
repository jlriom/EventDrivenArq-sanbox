using System.Threading.Tasks;

namespace Common.Data.Core
{
    public interface IRepository<T> : IReadonlyRepository<T> where T : class
    {
        Task DeleteAsync(params object[] keyValues);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity, params object[] keyValues);
    }
}
