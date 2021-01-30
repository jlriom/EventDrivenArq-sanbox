using Microsoft.AspNetCore.Http;

namespace Sandbox.Doc.Api.Dtos
{
    public class DocumentRequestDto : DocumentPropertiesRequestDto
    {
        public IFormFile File { get; set; }
    }
}
