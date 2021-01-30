using Automatonymous;
using Common.Application.Services.BlobStorage;
using MassTransit.MessageData;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{
    public class UpdateDocumentInStorage : DocumentActivity<UpdateDocumentInStorage, UpdateDocumentState, UpdateDocumentCommand>
    {
        private readonly IBlobStorageClient _blobStorageClient;
        private readonly IMessageDataRepository _messageDataRepository;

        public UpdateDocumentInStorage(
            ILogger<UpdateDocumentInStorage> logger,
            IBlobStorageClient blobStorageClient,
            IMessageDataRepository messageDataRepository
            ) : base(logger)
        {
            _blobStorageClient = blobStorageClient;
            _messageDataRepository = messageDataRepository;
        }
        public override Task Execute(BehaviorContext<UpdateDocumentState, UpdateDocumentCommand> context, Behavior<UpdateDocumentState, UpdateDocumentCommand> next)
        {
            var doc = context.Data.PayLoad.ToDocument(_messageDataRepository);
            _blobStorageClient.Put(doc.Id, doc.Content, context.Data.User.Token).Wait();
            return next.Execute(context);
        }
    }
}
