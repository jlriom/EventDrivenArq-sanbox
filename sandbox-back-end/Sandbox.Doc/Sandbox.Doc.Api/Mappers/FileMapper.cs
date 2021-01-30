using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using FileDto = Sandbox.Doc.WriteStack.Application.Commands.Dtos.FileDto;

namespace Sandbox.Doc.Api.Mappers
{
    public class FileMapper : Profile
    {
        public FileMapper()
        {
            CreateMap<IFormFile, FileDto>().ConstructUsing(src => FileFactory.CreateFrom(src));
        }

        private static class FileFactory
        {
            public static FileDto CreateFrom(IFormFile src)
            {
                using var ms = new MemoryStream();
                src.CopyTo(ms);
                return new FileDto(src.FileName, src.ContentType, ms.ToArray());
            }
        }
    }
}