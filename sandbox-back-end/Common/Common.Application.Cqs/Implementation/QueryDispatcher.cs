using Common.Application.Cqs.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Implementation
{
    public class QueryDispatcher : Bus, IQueryDispatcher
    {
        public QueryDispatcher(IMediator mediator) : base(mediator)
        {
        }

        public Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
            where TResult : class
        {
            return Mediator.Send(query, cancellationToken);
        }
    }
}