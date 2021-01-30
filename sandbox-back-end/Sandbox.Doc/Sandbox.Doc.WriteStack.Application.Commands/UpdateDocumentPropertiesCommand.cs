using System;

namespace Sandbox.Doc.WriteStack.Application.Commands
{
    public class UpdateDocumentPropertiesCommand : DocumentCommandBase
    {
        public UpdateDocumentPropertiesCommand(
            Guid id,
            string name,
            int documentStatusId)
            : base(name, documentStatusId)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}