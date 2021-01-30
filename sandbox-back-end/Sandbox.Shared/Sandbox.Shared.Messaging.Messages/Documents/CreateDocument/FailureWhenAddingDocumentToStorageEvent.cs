using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class FailureWhenAddingDocumentToStorageEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenAddingDocumentToStorageEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
