using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Core;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Implementation
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        protected readonly IBus Bus;
        protected readonly ILogger<TQuery> Logger;
        protected readonly IMapper Mapper;

        protected QueryHandler(IQueryDispatcher bus, IMapper mapper, ILogger<TQuery> logger)
        {
            Bus = bus;
            Mapper = mapper;
            Logger = logger;
        }

        public Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Handler Input: {request.Serialize()}");
            return HandleEx(request, cancellationToken);
        }

        protected abstract Task<TResult> HandleEx(TQuery query, CancellationToken cancellationToken = default);
    }
}