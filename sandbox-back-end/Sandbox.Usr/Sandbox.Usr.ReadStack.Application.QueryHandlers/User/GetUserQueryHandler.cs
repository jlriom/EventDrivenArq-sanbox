using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.Extensions.Logging;
using Sandbox.Usr.ReadStack.Application.Queries.User;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Usr.ReadStack.Application.QueryHandlers.User
{
    public class GetUserQueryHandler : QueryHandler<GetUserQuery, UserDto>
    {

        public GetUserQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            ILogger<GetUserQuery> logger) : base(bus, mapper, logger)
        {
        }

        protected override async Task<UserDto> HandleEx(
            GetUserQuery query, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}