using CSharpFunctionalExtensions;
using MediatR;

namespace Common.Application.Cqs.Contracts
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }
}