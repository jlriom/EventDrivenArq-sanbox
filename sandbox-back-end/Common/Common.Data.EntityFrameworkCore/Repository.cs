using Common.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Data.EntityFrameworkCore
{
    public abstract class Repository<T, TDbContext> :
        ReadonlyRepository<T, TDbContext>,
        IRepository<T> where T : class
        where TDbContext : DbContext
    {

        protected Repository(TDbContext context) : base(context)
        {
        }

        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            var entity = await DbSet.FindAsync(keyValues);

            if (entity == null)
            {
                throw new KeyNotFoundException(typeof(T).Name);
            }

            DbSet.Remove(entity);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity, params object[] keyValues)
        {
            var foundEntity = await DbSet.FindAsync(keyValues);

            if (foundEntity == null)
            {
                DbSet.Update(entity);
            }
        }
    }
}