
using Sandbox.Doc.WriteStack.Application.Commands.Dtos;
using System;

namespace Sandbox.Doc.WriteStack.Application.Commands
{
    public class UpdateDocumentCommand : DocumentCommandBase
    {
        public UpdateDocumentCommand(
            Guid id,
            string name,
            int documentStatusId,
            FileDto file)
            : base(name, documentStatusId)
        {
            Id = id;
            File = file;
        }

        public Guid Id { get; set; }
        public FileDto File { get; }
    }
}