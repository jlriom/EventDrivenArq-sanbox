using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities
{
    public class UpdateDocumentInDb : DocumentActivity<UpdateDocumentInDb, UpdateDocumentState, DocumentUpdatedInStorageEvent>
    {
        private readonly IDocumentUnitOfWork _documentUnitOfWork;
        private readonly IDocumentRepository _documentRepository;

        public UpdateDocumentInDb(
            ILogger<UpdateDocumentInDb> logger,
            IDocumentUnitOfWork documentUnitOfWork,
            IDocumentRepository documentRepository
            ) : base(logger)
        {
            _documentUnitOfWork = documentUnitOfWork;
            _documentRepository = documentRepository;
        }

        public override Task Execute(BehaviorContext<UpdateDocumentState, DocumentUpdatedInStorageEvent> context, Behavior<UpdateDocumentState, DocumentUpdatedInStorageEvent> next)
        {
            var doc = context.Data.PayLoad.ToDocument();
            _documentRepository.UpdateAsync(doc).Wait();
            _documentUnitOfWork.CommitAsync().Wait();
            return next.Execute(context);
        }
    }
}
