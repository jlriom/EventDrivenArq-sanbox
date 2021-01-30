using MediatR;

namespace Common.Application.Cqs.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult> where TResult : class
    {
    }
}