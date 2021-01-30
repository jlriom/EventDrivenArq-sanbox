using MassTransit.MessageData;
using Sandbox.Doc.WriteStack.Domain;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Messaging.Messages.Documents;
using System;
using System.IO;

namespace Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions
{
    public static class DocumentExtensions
    {
        public static Document ToDocument(this DocumentDto documentDto, IMessageDataRepository messageDataRepository)
        {
            var document = documentDto.ToDocument();

            if (documentDto.Content.HasValue)
            {
                document.Content = GetArrayFromStream(messageDataRepository.Get(documentDto.Content.Address).Result);
            }

            return document;
        }

        public static Document ToDocument(this DocumentDto documentDto)
        {
            var document = new Document(documentDto.Id)
            {
                ContentType = documentDto.FileContentType,
                Name = documentDto.Name,
                DocumentName = documentDto.FileName,
                DocumentStatus = DocumentStatusFactory.Create(documentDto.DocumentStatusId),
                Created = new AuditTrack(documentDto.CreatedBy, documentDto.CreatedOn),
                Updated = new AuditTrack(documentDto.UpdatedBy, documentDto.UpdatedOn)
            };

            return document;
        }

        public static Document ToEmptyDocumentWithId(this DocumentDto documentDto)
        {
            return new Document(documentDto.Id);
        }

        public static Document ToEmptyDocumentWithId(this Guid documentId)
        {
            return new Document(documentId);
        }

        public static DocumentDto ToDto(this Document document)
        {
            return new DocumentDto(
                document.Id,
                document.Name,
                (int)document.DocumentStatus.Id,
                document.DocumentName,
                document.ContentType,
                document.Created.On,
                document.Created.UserId,
                document.Updated.On,
                document.Updated.UserId,
                null);
        }

        private static byte[] GetArrayFromStream(Stream sourceStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                sourceStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
