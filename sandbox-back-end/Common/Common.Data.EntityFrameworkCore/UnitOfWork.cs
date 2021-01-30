using Common.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Common.Data.EntityFrameworkCore
{
    public class UnitOfWork<TDbContext>
        where TDbContext : DbContext,
        IUnitOfWork
    {
        private readonly TDbContext _context;

        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.CommitAsync();
        }
    }
}
