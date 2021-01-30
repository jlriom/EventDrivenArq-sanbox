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
    public class UpdateMyProfileHandler : CommandHandler<UpdateMyProfileCommand>
    {
        public UpdateMyProfileHandler(
            ICommandDispatcher bus,
            IMapper mapper,
            ILogger<UpdateMyProfileCommand> logger)
            : base(bus, mapper, logger)
        {
        }

        protected override Task<Result> HandleEx(UpdateMyProfileCommand command, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}