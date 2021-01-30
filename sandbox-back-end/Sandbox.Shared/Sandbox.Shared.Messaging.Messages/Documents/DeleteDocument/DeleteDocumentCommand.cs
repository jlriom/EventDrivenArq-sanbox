using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class DeleteDocumentCommand : MessageBase<Guid>
    {

        public DeleteDocumentCommand(Guid documentId) : base(documentId)
        {
        }
    }
}
