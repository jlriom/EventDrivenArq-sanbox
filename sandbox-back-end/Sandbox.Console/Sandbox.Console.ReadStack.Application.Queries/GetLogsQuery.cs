using Common.Application.Cqs.Implementation;
using Sandbox.Console.ReadStack.Application.Queries.Dtos;

namespace Sandbox.Console.ReadStack.Application.Queries
{
    public class GetLogsQuery : PagedQuery<LogEntryDto>
    {
        public GetLogsQuery(int limit, int offset) : base(limit, offset)
        {
        }
    }
}