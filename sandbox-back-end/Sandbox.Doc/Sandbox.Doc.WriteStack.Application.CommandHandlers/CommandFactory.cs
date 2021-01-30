using System;
using MassTransit;
using MassTransit.MessageData;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.CommandHandlers
{
    public class CommandFactory
    {
        public async Task<CreateDocumentCommand> CreateCreateDocumentCommand(Document document, IMessageDataRepository messageDataRepository)
        {
            var messageData = await messageDataRepository.PutBytes(document.Content, TimeSpan.FromMinutes(10));

            var createDocumentCommand = new CreateDocumentCommand(
                document.Id, document.Name, (int)document.DocumentStatus.Id,
                document.DocumentName, document.ContentType,
                document.Created.On, document.Created.UserId,
                document.Updated.On, document.Updated.UserId,
                messageData);

            return createDocumentCommand;
        }
        public async Task<UpdateDocumentCommand> CreateUpdateDocumentCommand(Document document, IMessageDataRepository messageDataRepository)
        {
            var messageData = await messageDataRepository.PutBytes(document.Content, TimeSpan.FromMinutes(10));
            var updateDocumentCommand =
                new UpdateDocumentCommand(
                    document.Id, document.Name, (int)document.DocumentStatus.Id,
                    document.DocumentName, document.ContentType,
                    document.Updated.On, document.Updated.UserId,
                    document.Updated.On, document.Updated.UserId,
                    messageData);

            return updateDocumentCommand;
        }

        public DeleteDocumentCommand CreateDeleteDocumentCommand(Document document)
        {
            return new DeleteDocumentCommand(document.Id);
        }
    }
}
