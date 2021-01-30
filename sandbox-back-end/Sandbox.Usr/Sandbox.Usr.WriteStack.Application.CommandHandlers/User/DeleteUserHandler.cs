using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Sandbox.Usr.WriteStack.Application.Commands.User;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Usr.WriteStack.Application.CommandHandlers.User
{
    public class DeleteUserHandler : CommandHandler<DeleteUserCommand>
    {
        public DeleteUserHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            ILogger<DeleteUserCommand> logger)
            : base(bus, mapper, logger)
        {
        }

        protected override Task<Result> HandleEx(DeleteUserCommand command, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}