using Sandbox.Doc.WriteStack.Application.Commands.Dtos;

namespace Sandbox.Doc.WriteStack.Application.Commands
{
    public class CreateDocumentCommand : DocumentCommandBase
    {
        public CreateDocumentCommand(
            string name,
            int documentStatusId,
            FileDto file)
            : base(name, documentStatusId)
        {
            File = file;
        }

        public FileDto File { get; }
    }
}