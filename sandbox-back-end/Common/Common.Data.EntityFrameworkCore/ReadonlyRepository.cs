using Common.Data.Core;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Data.EntityFrameworkCore
{

    public abstract class ReadonlyRepository<T, TDbContext> : IReadonlyRepository<T> where T : class
       where TDbContext : DbContext
    {
        protected readonly DbSet<T> DbSet;

        protected ReadonlyRepository(TDbContext context)
        {
            DbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(DbSet.ToList());
        }

        public virtual async Task<(IEnumerable<T>, int)> GetAsync<TKey>(
            Func<T, bool> predicate,
            Func<T, TKey> keySelector,
            int limit,
            int offset)
        {
            var entitiesCount = DbSet.Count(predicate);
            var entities = DbSet
               .Where(predicate)
               .OrderBy(keySelector).Skip(offset).Take(limit).ToList();
            return await Task.FromResult((entities, entitiesCount));
        }

        public virtual async Task<(IEnumerable<T>, int)> GetAsync<TKey, TProperty>(
            Expression<Func<T, TProperty>> navigationPropertyPath,
            Func<T, bool> predicate,
            Func<T, TKey> keySelector,
            int limit,
            int offset)
        {
            var entitiesCount = DbSet.Count(predicate);
            var entities = DbSet
               .Include(navigationPropertyPath)
               .Where(predicate)
               .OrderBy(keySelector).Skip(offset).Take(limit).ToList();
            return await Task.FromResult((entities, entitiesCount));
        }

        public virtual async Task<Maybe<T>> FindAsync(params object[] keyValues)
        {
            var entity = await DbSet.FindAsync(keyValues);
            return entity != null ? Maybe<T>.From(entity) : Maybe<T>.None;
        }
    }
}
