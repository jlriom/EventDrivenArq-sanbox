using AutoMapper;
using Microsoft.Extensions.Configuration;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;

namespace Sandbox.Console.ReadStack.Application.QueryHandlers.Mappers
{
    public class ConfigurationSettingDtoMapper : Profile
    {
        public ConfigurationSettingDtoMapper()
        {
            CreateMap<IConfigurationSection, ConfigurationSettingDto>();
        }
    }
}