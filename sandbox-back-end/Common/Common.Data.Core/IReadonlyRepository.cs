using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Data.Core
{
    public interface IReadonlyRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<(IEnumerable<T>, int)> GetAsync<TKey>(
            Func<T, bool> predicate,
            Func<T, TKey> keySelector,
            int limit,
            int offset);

        Task<(IEnumerable<T>, int)> GetAsync<TKey, TProperty>(
            Expression<Func<T, TProperty>> navigationPropertyPath,
            Func<T, bool> predicate,
            Func<T, TKey> keySelector,
            int limit,
            int offset);

        Task<Maybe<T>> FindAsync(params object[] keyValues);
    }
}
