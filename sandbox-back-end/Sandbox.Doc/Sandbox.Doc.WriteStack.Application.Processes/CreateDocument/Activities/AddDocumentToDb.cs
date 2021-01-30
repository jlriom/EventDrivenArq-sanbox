using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class AddDocumentToDb : DocumentActivity<AddDocumentToDb, CreateDocumentState, DocumentAddedToStorageEvent>
    {
        private readonly IDocumentUnitOfWork _documentUnitOfWork;
        private readonly IDocumentRepository _documentRepository;

        public AddDocumentToDb(
            ILogger<AddDocumentToDb> logger,
            IDocumentUnitOfWork documentUnitOfWork,
            IDocumentRepository documentRepository) : base(logger)
        {
            _documentUnitOfWork = documentUnitOfWork;
            _documentRepository = documentRepository;
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, DocumentAddedToStorageEvent> context, Behavior<CreateDocumentState, DocumentAddedToStorageEvent> next)
        {
            var doc = context.Data.PayLoad.ToDocument();
            _documentRepository.InsertAsync(doc).Wait();
            _documentUnitOfWork.CommitAsync().Wait();
            return next.Execute(context);
        }
    }
}
