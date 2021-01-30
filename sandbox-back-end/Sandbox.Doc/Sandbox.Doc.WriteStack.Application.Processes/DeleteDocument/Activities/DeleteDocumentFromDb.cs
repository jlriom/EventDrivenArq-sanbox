using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities
{
    public class DeleteDocumentFromDb : DocumentActivity<DeleteDocumentFromDb, DeleteDocumentState, DocumentDeletedFromStorageEvent>
    {
        private readonly IDocumentUnitOfWork _documentUnitOfWork;
        private readonly IDocumentRepository _documentRepository;

        public DeleteDocumentFromDb(
            ILogger<DeleteDocumentFromDb> logger,
            IDocumentUnitOfWork documentUnitOfWork,
            IDocumentRepository documentRepository
            ) : base(logger)
        {
            _documentUnitOfWork = documentUnitOfWork;
            _documentRepository = documentRepository;
        }

        public override Task Execute(BehaviorContext<DeleteDocumentState, DocumentDeletedFromStorageEvent> context, Behavior<DeleteDocumentState, DocumentDeletedFromStorageEvent> next)
        {
            var doc = context.Data.PayLoad.ToEmptyDocumentWithId();
            _documentRepository.DeleteAsync(doc).Wait();
            _documentUnitOfWork.CommitAsync().Wait();
            return next.Execute(context);
        }
    }
}
