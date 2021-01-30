using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class FailureWhenUpdatingDocumentInStorageEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenUpdatingDocumentInStorageEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
