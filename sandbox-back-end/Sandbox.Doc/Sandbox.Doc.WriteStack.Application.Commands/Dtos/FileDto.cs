using Newtonsoft.Json;

namespace Sandbox.Doc.WriteStack.Application.Commands.Dtos
{
    public class FileDto
    {
        public FileDto(string fileName, string fileContentType, byte[] fileContent)
        {
            FileName = fileName;
            FileContentType = fileContentType;
            FileContent = fileContent;
        }

        public string FileName { get; }
        public string FileContentType { get; }
        [JsonIgnore]
        public byte[] FileContent { get; }
    }
}