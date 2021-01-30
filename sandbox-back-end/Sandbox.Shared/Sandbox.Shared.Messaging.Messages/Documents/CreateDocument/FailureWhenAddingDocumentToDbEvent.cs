using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class FailureWhenAddingDocumentToDbEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenAddingDocumentToDbEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
