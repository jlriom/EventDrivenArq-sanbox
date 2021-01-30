using System.Collections.Generic;

namespace Common.Application.Cqs.Implementation
{
    public class Paging<T>
    {
        public Paging(IEnumerable<T> items, int limit, int offset, int total)
        {
            Items = items;
            Limit = limit;
            Offset = offset;
            Total = total;
        }

        public IEnumerable<T> Items { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
    }
}