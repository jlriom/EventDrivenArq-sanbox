using Common.Application.Cqs.Contracts;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;
using System.Collections.Generic;

namespace Sandbox.Console.ReadStack.Application.Queries
{
    public class GetConfigurationSettingsQuery : IQuery<IEnumerable<ConfigurationSettingDto>>
    {
    }
}