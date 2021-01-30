using System;

namespace Sandbox.Shared.Messaging.Messages.Documents
{
    public class DocumentDtoProperties
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int DocumentStatusId { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public DocumentDtoProperties(
            Guid id,
            string name,
            int documentStatusId,
            string fileName,
            string fileContentType,
            DateTime createdOn,
            Guid createdBy,
            DateTime updatedOn,
            Guid updatedBy)
        {
            Id = id;
            Name = name;
            DocumentStatusId = documentStatusId;
            FileName = fileName;
            FileContentType = fileContentType;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
        }
    }
}
