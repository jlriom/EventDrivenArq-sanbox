using AutoMapper;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using Sandbox.Shared.Data.Documents.Core;

namespace Sandbox.Doc.ReadStack.Application.QueryHandlers.Mappers
{
    public class DocumentPropertiesMapper : Profile
    {
        public DocumentPropertiesMapper()
        {
            CreateMap<Document, DocumentPropertiesDto>();
        }
    }
}
