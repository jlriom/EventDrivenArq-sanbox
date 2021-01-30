using Common.Application.Cqs.Contracts;

namespace Common.Application.Cqs.Implementation
{
    public abstract class PagedQuery<T> : IQuery<Paging<T>>
        where T : class
    {
        protected PagedQuery(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }

        public int Limit { get; }
        public int Offset { get; }
    }
}