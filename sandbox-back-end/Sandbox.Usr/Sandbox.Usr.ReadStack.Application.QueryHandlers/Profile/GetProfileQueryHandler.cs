using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.Extensions.Logging;
using Sandbox.Usr.ReadStack.Application.Queries.Profile;
using Sandbox.Usr.ReadStack.Application.Queries.Profile.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Usr.ReadStack.Application.QueryHandlers.Profile
{
    public class GetProfileQueryHandler : QueryHandler<GetProfileQuery, ProfileDto>
    {

        public GetProfileQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            ILogger<GetProfileQuery> logger) : base(bus, mapper, logger)
        {
        }

        protected override async Task<ProfileDto> HandleEx(
            GetProfileQuery query, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}