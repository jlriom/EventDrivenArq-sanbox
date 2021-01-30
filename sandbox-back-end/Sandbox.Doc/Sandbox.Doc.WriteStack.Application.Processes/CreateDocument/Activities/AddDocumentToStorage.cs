using Automatonymous;
using Common.Application.Services.BlobStorage;
using MassTransit.MessageData;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class AddDocumentToStorage : DocumentActivity<AddDocumentToStorage, CreateDocumentState, CreateDocumentCommand>
    {
        private readonly IBlobStorageClient _blobStorageClient;
        private readonly IMessageDataRepository _messageDataRepository;

        public AddDocumentToStorage(
            ILogger<AddDocumentToStorage> logger,
            IBlobStorageClient blobStorageClient,
            IMessageDataRepository messageDataRepository
            ) : base(logger)
        {
            _blobStorageClient = blobStorageClient;
            _messageDataRepository = messageDataRepository;
        }
        public override Task Execute(BehaviorContext<CreateDocumentState, CreateDocumentCommand> context, Behavior<CreateDocumentState, CreateDocumentCommand> next)
        {
            var doc = context.Data.PayLoad.ToDocument(_messageDataRepository);
            _blobStorageClient.Post(doc.Id, doc.Content, context.Data.User.Token).Wait();
            return next.Execute(context);
        }
    }
}
