using Common.Application.Cqs.Implementation;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;

namespace Sandbox.Doc.ReadStack.Application.Queries
{
    public class SearchDocumentsQuery : PagedQuery<DocumentPropertiesDto>
    {
        public SearchDocumentsQuery(int limit, int offset) : base(limit, offset)
        {
        }
    }
}