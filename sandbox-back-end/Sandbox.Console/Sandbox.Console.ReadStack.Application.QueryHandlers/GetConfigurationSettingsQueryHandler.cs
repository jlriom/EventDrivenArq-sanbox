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
    public class GetConfigurationSettingsQueryHandler
        : QueryHandler<GetConfigurationSettingsQuery, IEnumerable<ConfigurationSettingDto>>
    {
        private readonly IConfigurationSettingsService _configurationSettingsService;

        public GetConfigurationSettingsQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            ILogger<GetConfigurationSettingsQuery> logger,
            IConfigurationSettingsService configurationSettingsService) : base(bus, mapper, logger)
        {
            _configurationSettingsService = configurationSettingsService;
        }

        protected override async Task<IEnumerable<ConfigurationSettingDto>> HandleEx(
            GetConfigurationSettingsQuery query, CancellationToken cancellationToken = default)
        {
            var settings = await _configurationSettingsService.GetConfigurationSettings();
            return Mapper.Map<IEnumerable<ConfigurationSettingDto>>(settings);
        }
    }
}