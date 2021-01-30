using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.ReadStack.Application.Queries;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using Sandbox.Doc.ReadStack.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.ReadStack.Application.QueryHandlers
{
    public class SearchDocumentsQueryHandler : QueryHandler<SearchDocumentsQuery, Paging<DocumentPropertiesDto>>
    {
        private readonly IDocumentReadonlyRepository _documentReadonlyRepository;

        public SearchDocumentsQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            IDocumentReadonlyRepository documentReadonlyRepository,

            ILogger<SearchDocumentsQuery> logger) : base(bus, mapper, logger)
        {
            _documentReadonlyRepository = documentReadonlyRepository;
        }

        protected override async Task<Paging<DocumentPropertiesDto>> HandleEx(
            SearchDocumentsQuery query, CancellationToken cancellationToken = default)
        {
            var (docs, total) = await _documentReadonlyRepository
                    .GetAsync(d => true, d => d.Name, query.Limit, query.Offset);

            return new Paging<DocumentPropertiesDto>(Mapper.Map<List<DocumentPropertiesDto>>(docs), query.Limit, query.Offset, total);
        }
    }
}