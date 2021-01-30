using MassTransit;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class UpdateDocumentCommand : MessageBase<DocumentDto>
    {
        public UpdateDocumentCommand(
            Guid documentId,
            string name,
            int documentStatusId,
            string fileName,
            string fileContentType,
            DateTime createdOn,
            Guid createdBy,
            DateTime updatedOn,
            Guid updatedBy,
            MessageData<byte[]> content)
            : base(new DocumentDto(
                documentId,
                name,
                documentStatusId,
                fileName,
                fileContentType,
                createdOn,
                createdBy,
                updatedOn,
                updatedBy,
                content))
        {
        }
    }
}
