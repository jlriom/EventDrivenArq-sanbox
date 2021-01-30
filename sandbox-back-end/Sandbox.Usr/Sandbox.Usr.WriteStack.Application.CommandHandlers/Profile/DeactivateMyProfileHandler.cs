using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Sandbox.Usr.WriteStack.Application.Commands.Profile;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Usr.WriteStack.Application.CommandHandlers.Profile
{
    public class DeactivateMyProfileHandler : CommandHandler<DeactivateMyProfileCommand>
    {
        public DeactivateMyProfileHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            ILogger<DeactivateMyProfileCommand> logger)
            : base(bus, mapper, logger)
        {
        }

        protected override Task<Result> HandleEx(DeactivateMyProfileCommand command, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}