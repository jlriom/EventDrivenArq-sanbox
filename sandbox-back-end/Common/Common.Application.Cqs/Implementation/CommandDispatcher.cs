using Common.Application.Cqs.Contracts;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Implementation
{
    public class CommandDispatcher : Bus, ICommandDispatcher
    {
        public CommandDispatcher(IMediator mediator) : base(mediator)
        {
        }

        public Task<Result> Dispatch(ICommand command, CancellationToken cancellationToken = default)
        {
            return Mediator.Send(command, cancellationToken);
        }
    }
}