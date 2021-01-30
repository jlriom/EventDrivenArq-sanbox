using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Contracts
{
    public interface IQueryDispatcher : IBus
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
            where TResult : class;
    }
}