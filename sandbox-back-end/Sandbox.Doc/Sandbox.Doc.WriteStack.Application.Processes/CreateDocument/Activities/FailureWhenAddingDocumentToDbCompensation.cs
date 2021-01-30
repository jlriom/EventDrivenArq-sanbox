using Automatonymous;
using Common.Application.Services.BlobStorage;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class FailureWhenAddingDocumentToDbCompensation : DocumentActivity<FailureWhenAddingDocumentToDbCompensation, CreateDocumentState, FailureWhenAddingDocumentToDbEvent>
    {
        private readonly IBlobStorageClient _blobStorageClient;

        public FailureWhenAddingDocumentToDbCompensation(
            ILogger<FailureWhenAddingDocumentToDbCompensation> logger,
            IBlobStorageClient blobStorageClient
        ) : base(logger)
        {
            _blobStorageClient = blobStorageClient;
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, FailureWhenAddingDocumentToDbEvent> context, Behavior<CreateDocumentState, FailureWhenAddingDocumentToDbEvent> next)
        {
            var doc = context.Data.PayLoad.Data.ToEmptyDocumentWithId();
            _blobStorageClient.Delete(doc.Id, context.Data.User.Token).Wait();
            return next.Execute(context);
        }
    }
}
