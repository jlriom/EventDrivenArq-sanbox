using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.Extensions.Logging;
using Sandbox.Usr.ReadStack.Application.Queries.User;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Usr.ReadStack.Application.QueryHandlers.User
{
    public class
        SearchUsersQueryHandler : QueryHandler<SearchUsersQuery, Paging<UserDto>>
    {

        public SearchUsersQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            ILogger<SearchUsersQuery> logger) : base(bus, mapper, logger)
        {
        }

        protected override async Task<Paging<UserDto>> HandleEx(
            SearchUsersQuery query, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }
    }
}