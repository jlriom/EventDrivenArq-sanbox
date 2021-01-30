using AutoMapper;
using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using Common.Application.Exceptions;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.ReadStack.Application.Queries;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using Sandbox.Doc.ReadStack.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Doc.ReadStack.Application.QueryHandlers
{
    public class DocumentPropertiesQueryHandler : QueryHandler<DocumentPropertiesQuery, DocumentPropertiesDto>
    {
        private readonly IDocumentReadonlyRepository _documentReadonlyRepository;

        public DocumentPropertiesQueryHandler(
            IQueryDispatcher bus,
            IMapper mapper,
            IDocumentReadonlyRepository documentReadonlyRepository,
            ILogger<DocumentPropertiesQuery> logger) : base(bus, mapper, logger)
        {
            _documentReadonlyRepository = documentReadonlyRepository;
        }

        protected override async Task<DocumentPropertiesDto> HandleEx(
            DocumentPropertiesQuery query, CancellationToken cancellationToken = default)
        {
            var doc = await _documentReadonlyRepository.FindAsync(query.Id);

            if (doc.HasNoValue)
            {
                throw new NotFoundException();
            }

            return Mapper.Map<DocumentPropertiesDto>(doc.Value);
        }
    }
}