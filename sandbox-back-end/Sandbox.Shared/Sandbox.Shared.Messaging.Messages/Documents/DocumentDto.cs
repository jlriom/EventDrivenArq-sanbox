using MassTransit;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents
{
    public class DocumentDto : DocumentDtoProperties
    {
        public MessageData<byte[]> Content { get; set; }

        public DocumentDto(
            Guid id,
            string name,
            int documentStatusId,
            string fileName,
            string fileContentType,
            DateTime createdOn,
            Guid createdBy,
            DateTime updatedOn,
            Guid updatedBy,
            MessageData<byte[]> content)
            : base(id, name, documentStatusId, fileName, fileContentType, createdOn, createdBy, updatedOn, updatedBy)
        {
            Content = content;
        }
    }
}
