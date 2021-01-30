using MediatR;

namespace Common.Application.Cqs.Contracts
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
    }
}