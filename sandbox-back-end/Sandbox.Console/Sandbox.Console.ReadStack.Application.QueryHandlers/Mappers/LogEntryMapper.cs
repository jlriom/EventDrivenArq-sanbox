using AutoMapper;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;
using Sandbox.Shared.Data.System.Core;

namespace Sandbox.Console.ReadStack.Application.QueryHandlers.Mappers
{
    public class LogEntryMapper : Profile
    {
        public LogEntryMapper()
        {
            CreateMap<LogEntry, LogEntryDto>();
        }
    }
}
