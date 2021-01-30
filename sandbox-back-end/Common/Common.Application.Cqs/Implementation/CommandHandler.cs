using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Core;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Implementation
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly IBus Bus;
        protected readonly ILogger<TCommand> Logger;
        protected readonly IMapper Mapper;

        protected CommandHandler(ICommandDispatcher bus, IMapper mapper, ILogger<TCommand> logger)
        {
            Bus = bus;
            Mapper = mapper;
            Logger = logger;
        }

        public Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Handler Input: {request.Serialize()}");
            return HandleEx(request, cancellationToken);
        }

        protected abstract Task<Result> HandleEx(TCommand command, CancellationToken cancellationToken = default);
    }
}