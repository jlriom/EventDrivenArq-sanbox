using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Application.Cqs.Contracts
{
    public interface ICommand : IRequest<Result>
    {
    }
}