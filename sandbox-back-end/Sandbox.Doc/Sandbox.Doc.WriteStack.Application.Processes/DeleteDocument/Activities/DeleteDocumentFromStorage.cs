using Automatonymous;
using Common.Application.Services.BlobStorage;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{
    public class DeleteDocumentFromStorage : DocumentActivity<DeleteDocumentFromStorage, DeleteDocumentState, DeleteDocumentCommand>
    {
        private readonly IBlobStorageClient _blobStorageClient;

        public DeleteDocumentFromStorage(
            ILogger<DeleteDocumentFromStorage> logger,
            IBlobStorageClient blobStorageClient
            ) : base(logger)
        {
            _blobStorageClient = blobStorageClient;
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, DeleteDocumentCommand> context, Behavior<DeleteDocumentState, DeleteDocumentCommand> next)
        {
            var doc = context.Data.PayLoad.ToEmptyDocumentWithId();
            _blobStorageClient.Delete(doc.Id, context.Data.User.Token).Wait();
            return next.Execute(context);
        }
    }
}
