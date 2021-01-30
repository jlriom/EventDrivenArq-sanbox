using Common.Data.EntityFrameworkCore;
using Sandbox.Console.ReadStack.Core;
using Sandbox.Shared.Data.System.Core;
using Sandbox.Shared.Data.System.EntityFrameworkCore;

namespace Sandbox.Console.ReadStack.Infrastructure
{
    public class LogReadonlyRepository : ReadonlyRepository<LogEntry, SystemDbContext>, ILogReadonlyRepository
    {
        public LogReadonlyRepository(SystemDbContext context) : base(context)
        {
        }
    }
}
