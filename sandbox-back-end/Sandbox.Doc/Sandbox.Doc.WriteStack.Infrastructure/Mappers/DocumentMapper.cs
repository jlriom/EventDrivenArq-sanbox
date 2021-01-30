using AutoMapper;
using Sandbox.Doc.WriteStack.Domain.Documents;

namespace Sandbox.Doc.WriteStack.Infrastructure.Mappers
{
    public class DocumentMapper : Profile
    {
        public DocumentMapper()
        {
            CreateMap<Document, Shared.Data.Documents.Core.Document>()
                .ForMember(
                    d => d.UpdatedBy,
                    d => d.MapFrom(s => s.Updated.UserId))
                .ForMember(
                    d => d.UpdatedOn,
                    d => d.MapFrom(s => s.Updated.On))
                .ForMember(
                    d => d.DocumentStatusId,
                    d => d.MapFrom(s => s.DocumentStatus.Id))
                .ForMember(
                    d => d.Name,
                    d => d.MapFrom(s => s.Name))
                .ForMember(
                    d => d.DocumentName,
                    d => d.MapFrom(s => s.DocumentName))
                .ForMember(
                    d => d.Id,
                    d => d.MapFrom(s => s.Id))
                .ForMember(d => d.CreatedBy, d => d.Ignore())
                .ForMember(d => d.CreatedOn, d => d.Ignore())
                .ForMember(d => d.DocumentStatus, d => d.Ignore())
                ;
        }
    }
}
