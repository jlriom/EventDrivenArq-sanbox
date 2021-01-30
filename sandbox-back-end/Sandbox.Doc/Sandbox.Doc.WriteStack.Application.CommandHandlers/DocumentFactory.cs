using Sandbox.Doc.WriteStack.Application.Commands;
using Sandbox.Doc.WriteStack.Domain;
using Sandbox.Doc.WriteStack.Domain.Documents;
using System;

namespace Sandbox.Doc.WriteStack.Application.CommandHandlers
{
    public class DocumentFactory
    {
        private readonly Guid _userId;
        private readonly DateTime _dateTime;

        public DocumentFactory(Guid userId, DateTime dateTime)
        {
            _userId = userId;
            _dateTime = dateTime;
        }

        public DocumentFactory(Guid userId) : this(userId, DateTime.Now)
        {
        }

        public Document CreateFromCommand(Guid id, CreateDocumentCommand command)
        {
            return new Document(id)
            {
                Name = command.Name,
                DocumentName = command.File.FileName,
                DocumentStatus = DocumentStatusFactory.Create(command.DocumentStatusId),
                Content = command.File.FileContent,
                ContentType = command.File.FileContentType,
                Created = new AuditTrack(_userId, _dateTime),
                Updated = new AuditTrack(_userId, _dateTime)
            };
        }

        public Document CreateFromCommand(UpdateDocumentCommand command)
        {
            return new Document(command.Id)
            {
                Name = command.Name,
                DocumentName = command.File.FileName,
                DocumentStatus = DocumentStatusFactory.Create(command.DocumentStatusId),
                Content = command.File.FileContent,
                ContentType = command.File.FileContentType,
                Updated = new AuditTrack(_userId, _dateTime)
            };
        }

        public Document CreateFromCommand(UpdateDocumentPropertiesCommand command)
        {
            return new Document(command.Id)
            {
                Name = command.Name,
                DocumentStatus = DocumentStatusFactory.Create(command.DocumentStatusId),
                Updated = new AuditTrack(_userId, _dateTime)
            };
        }

        public Document CreateFromCommand(DeleteDocumentCommand command)
        {
            return new Document(command.Id);
        }
    }
}
