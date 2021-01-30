using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.Extensions.Logging;
using Sandbox.Console.ReadStack.Application.Queries;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;
using Sandbox.Console.ReadStack.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Console.ReadStack.Application.QueryHandlers
{
    public class GetLogsQueryHandler
        : QueryHandler<GetLogsQuery, Paging<LogEntryDto>>
    {
        private readonly ILogReadonlyRepository _logReadonlyRepository;

        public GetLogsQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            ILogReadonlyRepository logReadonlyRepository,
            ILogger<GetLogsQuery> logger) : base(bus, mapper, logger)
        {
            _logReadonlyRepository = logReadonlyRepository;
        }

        protected override async Task<Paging<LogEntryDto>> HandleEx(
            GetLogsQuery query, CancellationToken cancellationToken = default)
        {
            var (logEntries, total) = await _logReadonlyRepository
                .GetAsync(d => true, d => d.Id, query.Limit, query.Offset);

            return new Paging<LogEntryDto>(Mapper.Map<List<LogEntryDto>>(logEntries), query.Limit, query.Offset, total);
        }
    }
}