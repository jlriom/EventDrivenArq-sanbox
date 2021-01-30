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
    public class CreateUserHandler : CommandHandler<CreateUserCommand>
    {
        public CreateUserHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            ILogger<CreateUserCommand> logger)
            : base(bus, mapper, logger)
        {
        }

        protected override Task<Result> HandleEx(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}